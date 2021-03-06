﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Configuration;

namespace MarsLander
{
    class TrajectoryModel
    {
        /// <summary>
        /// Planet's gravity in m/s^2
        /// </summary>
        private double gravity;
        /// <summary>
        /// Initial speed when trajectorymanager starts (should be terminal parachute velocity)
        /// </summary>
        private double initSpeed;
        /// <summary>
        /// Height at which the parachute will release
        /// </summary>        
        private double parachuteReleaseHeight;
        /// <summary>
        /// Height at which thrusters cut and drop the craft
        /// </summary>
        private double dropHeight;
        /// <summary>
        /// Thrust in m/s^2 generated by thruster
        /// </summary>        
        private double burnThrust;
        /// <summary>
        /// Target descent velocity from parachute release until small altitude
        /// </summary>
        private double targetDescentVelocityLarge;
        /// <summary>
        /// Target descent velocity from small release altitude until drop height
        /// </summary>
        private double targetDescentVelocitySmall;
        /// <summary>
        /// Height to switch to velocity target for small altitude
        /// </summary>
        private double targetDescentVelocitySmallAltitude;

        // ToDo - needs thruster reference variable;
        public TrajectoryModel(double setThrust, double setGravity, double setInitSpeed, double setParachuteReleaseHeight, double setDropHeight,
            double setTargetDescentVelocityLarge, double setTargetDescentVelocitySmall, double setTargetDescentVelocitySmallAltitude)
        {
            gravity = setGravity;
            initSpeed = setInitSpeed;
            parachuteReleaseHeight = setParachuteReleaseHeight;
            dropHeight = setDropHeight;
            burnThrust = setThrust;
            targetDescentVelocityLarge = setTargetDescentVelocityLarge;
            targetDescentVelocitySmall = setTargetDescentVelocitySmall;
            targetDescentVelocitySmallAltitude = setTargetDescentVelocitySmallAltitude;
        }

        /// <summary>
        /// This default constructor will load parameters from the Application Configuration file.
        /// </summary>
        public TrajectoryModel()
        {
            var AppSettingsData = ConfigurationManager.AppSettings;

            //string grav = AppSettingsData["Gravity"];// ConfigurationManager.AppSettings["Gravity"].ToString();
            gravity = Convert.ToDouble(AppSettingsData["Gravity"]);
            initSpeed = Convert.ToDouble(AppSettingsData["InitialSpeed"]);
            parachuteReleaseHeight = Convert.ToDouble(AppSettingsData["ParachuteReleaseHeight"]);
            dropHeight = Convert.ToDouble(AppSettingsData["DropHeight"]);
            burnThrust = Convert.ToDouble(AppSettingsData["BurnEffectiveness"]);
            targetDescentVelocityLarge = Convert.ToDouble(AppSettingsData["TargetDescentVelocityLarge"]);
            targetDescentVelocitySmall = Convert.ToDouble(AppSettingsData["TargetDescentVelocitySmall"]);
            targetDescentVelocitySmallAltitude = Convert.ToDouble(AppSettingsData["TargetDescentVelocitySmallAltitude"]);
        }

        public double calcThrottle(double currentAltitude, double descentSpeed)
        {
            double calculatedThrottle;
            if(currentAltitude > dropHeight && currentAltitude > 0 && currentAltitude < parachuteReleaseHeight)
            {
                if(currentAltitude > targetDescentVelocitySmallAltitude)
                {
                    if(descentSpeed >= targetDescentVelocityLarge)
                    {
                        // Set throttle to determined throttle algorithm output
                        calculatedThrottle = ((descentSpeed - targetDescentVelocityLarge) / gravity + 1) / (burnThrust / gravity);
                        // Sanitize to a max of one
                        calculatedThrottle = calculatedThrottle > 1 ? 1 : calculatedThrottle;
                        // Sanatize to a minimum of zero
                        calculatedThrottle = calculatedThrottle < 0 ? 0 : calculatedThrottle;
                        Debug.WriteLine("Alt: " + currentAltitude + " Vel: " + descentSpeed + " Res: " + calculatedThrottle);
                        return calculatedThrottle;
                    }
                    else
                    {
                        // Descent speed is lower than target so do not yet throttle up
                        Debug.WriteLine("Alt: " + currentAltitude + " Vel: " + descentSpeed + " Res: 0");
                        return 0;
                    }
                }
                else
                {
                    // Set throttle to determined throttle algorithm output
                    calculatedThrottle = ((descentSpeed - targetDescentVelocitySmall) / gravity + 1) / (burnThrust / gravity);
                    // Sanitize to a max of one
                    calculatedThrottle = calculatedThrottle > 1 ? 1 : calculatedThrottle;
                    // Sanatize to a minimum of zero
                    calculatedThrottle = calculatedThrottle < 0 ? 0 : calculatedThrottle;
                    Debug.WriteLine("Alt: " + currentAltitude + " Vel: " + descentSpeed + " Res: " + calculatedThrottle);
                    return calculatedThrottle;
                }
            }
            else
            {
                // Altitude too low or too high for thrusters
                Debug.WriteLine("Alt: " + currentAltitude + " Vel: " + descentSpeed + " Res: 0");
                return 0;
            }
        }

        public double GetParachuteTerminalVelocity()
        {
            return initSpeed;
        }

    /// <summary>
    /// The testing method for the Trajectory Model
    /// </summary>
    /// <returns>Returns success or failure status values based on tests</returns>
    public bool SelfTest()
        {
            /* For these test cases we test 15 different test cases looking for expected, manually calculated outputs with a known scenario
                Scenario -
                  Gravity = 8 m/s^2
                  Initial Speed = 8 m/s
                    Parachute Release Height = 5000m
                    Drop Height = 5m
                    Target Descent Velocity Large = 100 m/s
                    Target Descent Velocity Small = 5 m/s
                    Target Descent Velocity Altitude = 500m
                    Thruster Thrust = 24m/s^2
       
                Test Cases (form: altitude, descent velocity) - NOTE: 0.33333333333333331 is used for 1/3 throttle calculation due to under the hood math calculations and comparisons in c#
                10000m, 1000m/s = 0 throttle
                10000m, 100m/s = 0 throttle;
                10000m, 0m/s = 0 throttle
                4999m, 500m/s = 1 throttle;
                4999m, 100m/s = 0.33333333333333331 throttle;
                4999m, 0m/s = 0 throttle;
                501m, 500m/s = 1 throttle;
                501m, 100m/s = 0.33333333333333331 throttle;
                501m, 0m/2 = 0 throttle;
                250m, 75m/s = 1 throttle;
                250m, 5m/s = 0.33333333333333331 throttle;
                250m, 0m/s = .125 throttle;
                4m, 100m/s = 0 throttle;
                4m, 5m/s = 0 throttle;
                4m, 0m/s = 0 throttle;
            */
            bool returnVal = true;
            TrajectoryModel testTrajectoryModel = new TrajectoryModel(24, 8, 8, 5000, 5, 100, 5, 500);

            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(10000, 1000) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(10000, 100) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(10000, 0) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(4999, 500) == 1);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(4999, 100) == 0.33333333333333331);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(4999, 0) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(501, 500) == 1);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(501, 100) == 0.33333333333333331);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(501, 0) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(250, 75) == 1);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(250, 5) == 0.33333333333333331);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(250, 0) == .125);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(4, 100) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(4, 5) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testTrajectoryModel.calcThrottle(4, 0) == 0);
            }

            return returnVal;
        }

        #region Getters
        /// <summary>
        /// Read planet's gravity in m/s^2
        /// </summary>
        /// <returns>A double describing gravity</returns>
        public double GetGravity()
        {
            return gravity;
        }

        /// <summary>
        /// REad initial speed when trajectorymanager starts (should be terminal parachute velocity)
        /// </summary>
        /// <returns>A double describing speed</returns>
        public double GetInitSpeed()
        {
            return initSpeed;
        }

        /// <summary>
        /// Read height at which the parachute will release
        /// </summary>
        /// <returns>A double describing altitude</returns>
        public double GetParachuteReleaseHeight()
        {
            return parachuteReleaseHeight;
        }

        /// <summary>
        /// Read height at which thrusters cut and drop the craft
        /// </summary>
        /// <returns>A double describing altitude</returns>
        public double GetDropHeight()
        {
            return dropHeight;
        }

        /// <summary>
        /// Read thrust in m/s^2 generated by thruster
        /// </summary>
        /// <returns>A double describing thrust</returns>
        public double GetBurnThrust()
        {
            return burnThrust;
        }

        /// <summary>
        /// Read the height to switch to velocity target for small altitude
        /// </summary>
        /// <returns>A double describing descent velocity</returns>
        public double GetTargetDescentVelocityLarge()
        {
            return targetDescentVelocityLarge;
        }

        /// <summary>
        /// Target descent velocity from small release altitude until drop height
        /// </summary>
        /// <returns>A double describing descent velocity</returns>
        public double GetTargetDescentVelocitySmall()
        {
            return targetDescentVelocitySmall;
        }

        /// <summary>
        /// Height to switch to velocity target for small altitude
        /// </summary>
        /// <returns>A double describing altitude</returns>
        public double GetTargetDescentVelocitySmallAltitude()
        {
            return targetDescentVelocitySmallAltitude;
        }
        #endregion
    }
}
