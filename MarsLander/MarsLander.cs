using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading;

// Test Comment
namespace MarsLander
{
    public partial class MarsLanderNavSimulator : Form
    {
        public MarsLanderNavSimulator()
        {
            InitializeComponent();
            setupDefaultConfiguration();
        }

        /// <summary>
        /// This method will process the testing of application components when the user clicks the "Preflight" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestThruster_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Running pre-flight checks...\r\n";
            textBox2.Refresh();
            textBox2.Text += "Trajectory Model: ";
            textBox2.Text += ThrottleCalculator.SelfTest() == true ? "Success\r\n" : "Failure\r\n";
            textBox2.Text += "Thruster: ";
            textBox2.Text += MainThruster.SelfTest() == true ? "Success\r\n" : "Failure\r\n";
            textBox2.Text += "RollThruster: ";
            textBox2.Text += RollThruster.SelfTest() == true ? "Success\r\n" : "Failure\r\n";
            textBox2.Text += "AxialThruster: ";
            textBox2.Text += AxialThruster.SelfTest() == true ? "Success\r\n" : "Failure\r\n";
            textBox2.Text += "Guidance Control: ";
            textBox2.Text += GuidanceSystem.SelfTest() == true ? "Success\r\n" : "Failure\r\n";
            textBox2.Text += "Pre-flight checks completed.";

        }


        private void setupDefaultConfiguration()
        {
            txtAxialThrust.Text = ConfigurationManager.AppSettings["AxialThrust"];
            txtSetGrav.Text = ConfigurationManager.AppSettings["Gravity"];
            txtParachuteVel.Text = ConfigurationManager.AppSettings["ParachuteTerminalVelocity"];
            txtReleaseHeight.Text = ConfigurationManager.AppSettings["ParachuteReleaseHeight"];
            txtEngineCutHeight.Text = ConfigurationManager.AppSettings["EngineCutHeight"];
            txtSlowDescentHeight.Text = ConfigurationManager.AppSettings["SlowDecentHeight"];
            txtHighFallSpeed.Text = ConfigurationManager.AppSettings["TargetHighAltitudeFallSpeed"];
            txtLowFallSpeed.Text = ConfigurationManager.AppSettings["TargetLowAltitudeFallSpeed"];
            //GuidanceSystem.guidanceTrajectory

        }

        private void UpdateSettings_Click(object sender, EventArgs e)
        {
            //string regExInt = @"^\d+$";
            string regExDouble = @"^\d+\.?\d?$";

            bool validateSuccessful = true;

            lblSimulationSettings.Text = "Simulator Settings: configuration has been changed";

            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtAxialThrust.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtAxialThrust.BackColor = Color.White;
                }
                else
                {
                    txtAxialThrust.BackColor = Color.LightPink;
                }
            }
            
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtSetGrav.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtSetGrav.BackColor = Color.White;
                }
                else
                {
                    txtSetGrav.BackColor = Color.LightPink;
                }
            }
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtParachuteVel.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtParachuteVel.BackColor = Color.White;
                }
                else
                {
                    txtParachuteVel.BackColor = Color.LightPink;
                }
            }
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtReleaseHeight.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtReleaseHeight.BackColor = Color.White;
                }
                else
                {
                    txtReleaseHeight.BackColor = Color.LightPink;
                }
            }
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtEngineCutHeight.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtEngineCutHeight.BackColor = Color.White;
                }
                else
                {
                    txtEngineCutHeight.BackColor = Color.LightPink;
                }
            }
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtSlowDescentHeight.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtSlowDescentHeight.BackColor = Color.White;
                }
                else
                {
                    txtSlowDescentHeight.BackColor = Color.LightPink;
                }
            }
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtHighFallSpeed.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtHighFallSpeed.BackColor = Color.White;
                }
                else
                {
                    txtHighFallSpeed.BackColor = Color.LightPink;
                }
            }
            if (validateSuccessful)
            {
                validateSuccessful = validateInput(txtLowFallSpeed.Text, regExDouble);
                if (validateSuccessful)
                {
                    txtLowFallSpeed.BackColor = Color.White;
                }
                else
                {
                    txtLowFallSpeed.BackColor = Color.LightPink;
                }
            }

            if (validateSuccessful)
            {
                textBox1.Text += "New settings added:\r\n" +
                    "  Axial Engine Thrust - " + txtAxialThrust.Text + " (m/s^2)\r\n" +
                    "  Gravity - " + txtSetGrav.Text + " (m/s^2)\r\n" +
                    "  Parachute Terminal Velocity - " + txtParachuteVel.Text + " (m/s)\r\n" +
                    "  Parachute Release Height - " + txtReleaseHeight.Text + " (m)\r\n" +
                    "  Engine Cut Height - " + txtEngineCutHeight.Text + " (m)\r\n" +
                    "  Slow Descent Height - " + txtSlowDescentHeight.Text + " (m)\r\n" +
                    "  Target High Altitude Fall Speed - " + txtHighFallSpeed.Text + " (m/s)\r\n" +
                    "  Target Low Altitude Fall Speed - " + txtLowFallSpeed.Text + " (m/s)\r\n";
                GuidanceSystem.UpdateTrajectoryModel(Convert.ToDouble(txtAxialThrust.Text), Convert.ToDouble(txtSetGrav.Text), Convert.ToDouble(txtParachuteVel.Text), 
                    Convert.ToDouble(txtReleaseHeight.Text), Convert.ToDouble(txtEngineCutHeight.Text), Convert.ToDouble(txtHighFallSpeed.Text), 
                    Convert.ToDouble(txtLowFallSpeed.Text), Convert.ToDouble(txtSlowDescentHeight.Text));
            }
            else
            {
                textBox1.Text += "Validation Failed! Make sure you only have numbers in the boxes!\r\n";
                lblSimulationSettings.Text = "Simulator Settings:  CONFIGURATION ERROR!";
            }
        }
        
        private bool validateInput(string validateItem, string regularExpressionComparison)
        {
            bool returnVal = false;

            Regex regex = new Regex(regularExpressionComparison);
            Match match = regex.Match(validateItem);
            if (match.Success)
            {
                returnVal = true;
            }

            return returnVal;
        }

        private void TextBlock_Click(object sender, EventArgs e)
        {
            TextBox targetObject = (TextBox)sender;
            targetObject.BackColor = Color.White;
        }

        private void LetItFly_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            GuidanceSystem.InitGuidanceControl(ref textBox1);
        }

        private void ReadRecentFlightData_Click(object sender, EventArgs e)
        {
            string filePath = Application.ExecutablePath + @"DAT\";
            filePath = filePath.Replace(Application.ProductName, "").Replace(".exe", "");
            // Get a directory info object to look up files
            System.IO.DirectoryInfo diObj = new System.IO.DirectoryInfo(filePath);
            System.IO.FileSystemInfo[] fileSysObj = diObj.GetFileSystemInfos();
            if (fileSysObj.Length > 0)
            {
                // lambda expression to sort by created date
                var flightFiles = fileSysObj.OrderBy(f => f.CreationTime);
                string mostRecentFile = flightFiles.Last().ToString();
                filePath += mostRecentFile;
                FlightDataReader reader = new FlightDataReader(filePath);
                MessageBox.Show(filePath);
                reader.LoadFlightData();
                reader.Show();
            }
            else
            {
                MessageBox.Show("No flight data available.", "No flight data.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
