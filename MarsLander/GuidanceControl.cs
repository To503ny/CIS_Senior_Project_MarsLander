using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;

namespace MarsLander
{
    class GuidanceControl
    {
        //private variables
        private bool HasVehicleLanded = false; //no method for testing if we have landed
        private bool HasParachuteDetached = false;
        //predescribed vars
        private int PrescribedFreeFallAltitude = 5000;//This is just a test number

        // Values based off the default instantiated object below in TrajectoryModel
        private double altitude = 5000;
        private double velocity = 8;

        //public varialbles
        private bool ThrustersOn = false;//added to let us know the thrusters have been ignited
        //AxialThrusters vars
        private AxialThruster AxialAlpha = new AxialThruster();
        private AxialThruster AxialBeta = new AxialThruster();
        private AxialThruster AxialCharlie = new AxialThruster();
        //RollThrusters vars
        private RollThruster RollThrusterGroup = new RollThruster();
        //prescribed vars based off trajectory model default below
        private double PrescribedIgnitionAltitude = 5000;
        //connection TrajectoryModel Class
        private TrajectoryModel guidanceTrajectory = new TrajectoryModel();
        private StreamWriter DataRecorderCSV;
        //connection to MarsLander
        //public MarsLanderNavSimulator marsLanderNavSimulator = new MarsLanderNavSimulator();

        public GuidanceControl()
        {

        }

        public GuidanceControl(double setAltitude, double setVelocity, double setPrescribedIgnitionAltitude, int setPrescribedFreeFallAltitude)
        {
            altitude = setAltitude;
            velocity = setVelocity;
            PrescribedIgnitionAltitude = setPrescribedIgnitionAltitude;
            PrescribedFreeFallAltitude = setPrescribedFreeFallAltitude;
        }
        //Main Loop
        private void GuidanceControlLoop()
        {


            // Adjust flight - axis
            EvaluateVehicleFacingAngle();
            // Adjust flight - throttle
            AdjustThrust();
        }

        public void InitGuidanceControl(ref System.Windows.Forms.TextBox textBox1)
        {
            // Startup guidance control - init thrusters
            if (!IgniteAxialThrusters() || !ParachuteHasDetached())
            {
                MessageBox.Show("Guidance Control failed initialization due to problem.");
                return;
            }

            InitDataRecorder();
            while (altitude > 0 && altitude <= PrescribedIgnitionAltitude)
            {
                GetSensorData();
                GuidanceControlLoop();

                // Sleep?
                // Sleep 1 sec if we decide to
                ReportState(ref textBox1);
            }
            
            // Finished descent
            CloseDataRecorder();
        }

        private void ReportState(ref System.Windows.Forms.TextBox textBox1)
        {
            double currentThrottle = ((AxialAlpha.GetThrottle() + AxialBeta.GetThrottle() + AxialCharlie.GetThrottle()) / 3);
            if (altitude > 0) {

                textBox1.Text += "Craft is now at: " + String.Format("{0:N1}", altitude) + " meters, falling at " + String.Format("{0:N1}", velocity) + " meters per second. (Throttle: " +
                    String.Format("{0:N3}", currentThrottle) + ").\r\n";
                DataRecorderCSV.WriteLine(String.Format("{0:N1}", altitude) + ", " + String.Format("{0:N1}", velocity) + ", " + String.Format("{0:N3}", currentThrottle));
            }
            else
            {
                if (DidVehicleLandSafely(velocity)) {
                    textBox1.Text += "Craft landed at: " + String.Format("{0:N1}", velocity) + " meters per second.\r\n";
                    DataRecorderCSV.WriteLine("Craft landed at: " + String.Format("{0:N1}", velocity) + " meters per second.");
                }
                else {
                    textBox1.Text += "Craft crashed at: " + String.Format("{0:N1}", velocity) + " meters per second.\r\n";
                    DataRecorderCSV.WriteLine("Craft crashed at: " + String.Format("{0:N1}", velocity) + " meters per second.");
                }
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            textBox1.Refresh();
        }

        private void InitDataRecorder()
        {
            string filePath = Application.ExecutablePath + @"\DAT\";
            filePath = filePath.Replace(Application.ProductName, "").Replace(".exe", "");
            if (!(Directory.Exists(filePath))) { Directory.CreateDirectory(filePath); }
            filePath += @"flight-recorder-" + System.DateTime.Now.ToLongTimeString().Replace(":", "").Replace(" ", "").Replace("AM","").Replace("PM","") + ".csv";
            DataRecorderCSV = new StreamWriter(filePath,false);
            DataRecorderCSV.WriteLine("Configuration loaded:");
            DataRecorderCSV.WriteLine("Axial Thrust: " + AxialAlpha.GetThrust());
            DataRecorderCSV.WriteLine("Gravity: " + guidanceTrajectory.GetGravity());
            DataRecorderCSV.WriteLine("Parachute Terminal Velocity: " + guidanceTrajectory.GetParachuteTerminalVelocity());
            DataRecorderCSV.WriteLine("Parachute Release Height: " + guidanceTrajectory.GetParachuteTerminalVelocity());
            DataRecorderCSV.WriteLine("Engine Cut Height: " + guidanceTrajectory.GetDropHeight());
            DataRecorderCSV.WriteLine("Slow Descent Height: " + guidanceTrajectory.GetTargetDescentVelocitySmallAltitude());
            DataRecorderCSV.WriteLine("Target High Altitude Fall Speed: " + guidanceTrajectory.GetTargetDescentVelocityLarge());
            DataRecorderCSV.WriteLine("Target Low Altitude Fall Speed: " + guidanceTrajectory.GetTargetDescentVelocitySmall());
            DataRecorderCSV.WriteLine("\n\nAltitude, Velocity, Throttle");

        }

        /// <summary>
        /// This will close the StreamFile object
        /// </summary>
        private void CloseDataRecorder()
        {
            try
            {
                DataRecorderCSV.Flush();
                DataRecorderCSV.Close();
            }
            finally
            {
                DataRecorderCSV = null;
            }

            try
            {
                //
            }
            finally { }
        }

        // Emulate sensor inputs since we don't actually have sensors
        public void GetSensorData()
        {
            // Get sensor data - altimeter
            altitude = (altitude - velocity) > 0 ? (altitude - velocity) : 0;
            // Get sensor data - velocity
            double averageThrust = ((AxialAlpha.GetThrust() + AxialBeta.GetThrust() + AxialCharlie.GetThrust()) / 3);
            double Gravity = guidanceTrajectory.GetGravity();
            velocity = velocity - averageThrust + Gravity;
        }

        public void UpdateTrajectoryModel(double setThrust, double setGravity, double setInitSpeed, double setParachuteReleaseHeight, double setDropHeight,
            double setTargetDescentVelocityLarge, double setTargetDescentVelocitySmall, double setTargetDescentVelocitySmallAltitude)
        {
            guidanceTrajectory = new TrajectoryModel(setThrust, setGravity, setInitSpeed, setParachuteReleaseHeight, setDropHeight, setTargetDescentVelocityLarge, 
                setTargetDescentVelocitySmall, setTargetDescentVelocitySmallAltitude);
            AxialAlpha = new AxialThruster(setThrust);
            AxialBeta = new AxialThruster(setThrust);
            AxialCharlie = new AxialThruster(setThrust);

            altitude = setParachuteReleaseHeight;
            velocity = setInitSpeed;
            PrescribedIgnitionAltitude = setParachuteReleaseHeight;
        }

        private bool DidVehicleLandSafely(double _velocity)
        {
            double targetVelocity = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["TargetMaximumLandingVelocity"]);
            if(targetVelocity >= _velocity)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void EvaluateVehicleFacingAngle()
        {
            // Get direction from sensors
            double degreesToCorrect;

            // Get roll speed from sensors
            double rollToCorrect = GetRollRate();

            // First we correct the roll
            RollThrusterGroup.correctCurrentSpin(rollToCorrect);

            // Now we assess attitude
            degreesToCorrect = GetAttitudeSensorData();

            // Now correct any spin needed
            RollThrusterGroup.applyRollCorrection(degreesToCorrect);
        }

        private double GetAttitudeSensorData()
        {
            // Emulates sensor return data - would normally return directionality
            return 0;
        }

        private double GetRollRate()
        {
            // Emulates sensor return data - would normally return rate of rotation
            return 0;
        }

        private bool IgniteAxialThrusters()
        {
            bool returnVal = true;
            if (ThrustersOn == false)
            {
                try
                {
                    ThrustersOn = true;
                }
                catch
                {
                    MessageBox.Show("Thrusters failed to ignite!");
                    returnVal = false;
                }
            }
            return returnVal;
        }

        private void AdjustThrust()
        {
            double calculatedThrottle;
            //check to see lander is at PrescribedIgnitionAltitude
            if (PrescribedIgnitionAltitude >= altitude)
            {
                calculatedThrottle = guidanceTrajectory.calcThrottle(altitude, velocity);
                if (calculatedThrottle > 0) {
                    AxialAlpha.SetThrottle(calculatedThrottle);
                    AxialBeta.SetThrottle(calculatedThrottle);
                    AxialCharlie.SetThrottle(calculatedThrottle);
                }
                else
                {
                    AxialAlpha.SetThrottle(0);
                    AxialBeta.SetThrottle(0);
                    AxialCharlie.SetThrottle(0);
                }
            }
        }//end IgniteAxialThrusters()

        private bool ParachuteHasDetached()
        {
            bool returnVal = true;
            //Check to see if lander is at PrescribedFreeFallAltitude and the thrusters are ignited
            if (PrescribedFreeFallAltitude >= altitude)
            {
                try
                {
                    HasParachuteDetached = true;
                    ThrustersOn = true;
                    string parachuteDetached = "Parachute is detached, axial thrusters primed";
                    MessageBox.Show(parachuteDetached);
                }
                catch
                {
                    MessageBox.Show("Parachute failed to release.  Aborting.");
                    returnVal = false;
                }
            }
            return returnVal;
        }//end ParachuteHasDetached()

        private bool CheckLanded()
        {
            if(altitude <= 0)
            {
                HasVehicleLanded = true;
            }

            return HasVehicleLanded;
        }

        public bool SelfTest()
        {
            bool returnVal = true;
            GuidanceControl testGuidanceControl = new GuidanceControl(0, 0, 0, 0);

            /* Test cases
                - Create new guidance control objects
                    - One at 0, 0, 0, 0
                    - One at 5000, 8, 5000, 3000
                - Execute GetSensorData()
                - Run UpdateTrajectoryModel 
                    - One at (0, 0, 0, 0, 0, 0, 0, 0)
                    - One at (24, 8, 8, 5000, 5, 100, 5, 500)
                - Execute EvaluateVehicleFacingAngle()
                - Execute IgniteAxialThrusters()
                - Execute AdjustThrust()
                - Execute ParachuteHasDetached() = should result in true
                - Execute FireRollThrusters
                    - One at 0
                    - One at 1
                - Execute CheckLanded() = Should result in false
              
            */

            if (returnVal == true) {
               try
                {
                    testGuidanceControl = new GuidanceControl(0, 0, 0, 0);
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl = new GuidanceControl(5000, 8, 5000, 3000);
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl.GetSensorData();
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl.UpdateTrajectoryModel(0, 0, 0, 0, 0, 0, 0, 0);
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl.UpdateTrajectoryModel(24, 8, 8, 5000, 5, 100, 5, 500);
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl.EvaluateVehicleFacingAngle();
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl.IgniteAxialThrusters();
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    testGuidanceControl.AdjustThrust();
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    if (testGuidanceControl.ParachuteHasDetached() != true)
                    {
                        returnVal = false;
                    }
                }
                catch
                {
                    returnVal = false;
                }
            }
            if (returnVal == true)
            {
                try
                {
                    if (testGuidanceControl.CheckLanded() != false)
                    {
                        returnVal = false;
                    }
                }
                catch
                {
                    returnVal = false;
                }
            }

            return returnVal;
        }
    }//end GuidanceControl Class
}