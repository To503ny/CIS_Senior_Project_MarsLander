using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarsLander
{
    class AxialThruster
    {
        // thrustGenerated is a value in m/(s^2) for this engine
        protected double thrustGenerated;
        protected double throttle;

        public AxialThruster ()
        {
            thrustGenerated = 24;
            throttle = 0;
        }

        public AxialThruster(double setThrustGenerated)
        {
            // ToDo: For now we set a static value equal to roughly 3 earth, this will eventually be input from configuration parameters
            thrustGenerated = setThrustGenerated;
            throttle = 0;
        }

        public bool SetThrottle(double throttleInput)
        {
            try
            {
                if (throttleInput <= 1 && throttleInput >= 0)
                {
                    throttle = throttleInput;
                }
                else
                {
                    // Validation failed
                    throttle = 0;
                    return false;
                }
            }
            catch
            {
                // Other verification failure
                return false;
            }

            return true;
        }

        public double GetThrottle()
        {
            return throttle;
        }

        public double GetThrust()
        {
            return thrustGenerated * throttle;
        }

        public double GetThrustGenerated()
        {
            return thrustGenerated;
        }

        // Test cases
        public bool SelfTest()
        {
            AxialThruster testThruster;
            bool returnVal = true;
            
            /* For these test cases we test 5 different scenarios looking for expected, manually calculated outputs:
                -1 throttle = should fail
                0 throttle = should equal 0 thrust
                .5 throttle = should equal 12 thrust
                1 throttle = should equal 24 thrust
                2 throttle = should fail
            */

            // Test creation/constructor
            try
            {
                testThruster = new AxialThruster(24);
            }
            catch
            {
                // Log a failure or output message
                return false;
            }

            if (returnVal == true)
            {
                returnVal = RunThrottleTest(ref testThruster, -1, -1);
            }
            if (returnVal == true)
            {
                returnVal = RunThrottleTest(ref testThruster, 0, 0);
            }
            if (returnVal == true)
            {
                returnVal = RunThrottleTest(ref testThruster, .5, 12);
            }
            if (returnVal == true)
            {
                returnVal = RunThrottleTest(ref testThruster, 1, 24);
            }
            if (returnVal == true)
            {
                returnVal = RunThrottleTest(ref testThruster, 2, -1);
            }

            return returnVal;
        }

        private bool RunThrottleTest(ref AxialThruster testThruster, double throttleTest, int resultTest)
        {
            // Try setting throttle
            try
            {
                testThruster.SetThrottle(throttleTest);
            }
            catch
            {
                if (resultTest != -1)
                {
                    // Log a failure or output message
                    return false;
                }
            }

            // Try getting throttle
            if (resultTest == -1)
            {
                try
                {
                    if (testThruster.GetThrottle() != 0)
                    {
                        Debug.Write(testThruster.GetThrottle());
                        // Log a failure or output message
                        return false;
                    }
                }
                catch
                {
                    // Log a failure or output message
                    return false;
                }
            }
            else
            {
                if (testThruster.GetThrottle() != throttleTest)
                {
                    // Log a failure or output message
                    return false;
                }
            }

            // Try getting thrust
            if (resultTest == -1)
            {
                try
                {
                    if (testThruster.GetThrust() != 0)
                    {
                        // Log a failure or output message
                        return false;
                    }
                }
                catch
                {
                    // We expect failure possibilities depending on input
                }
            }
            else
            {
                try
                {
                    if (testThruster.GetThrust() != resultTest)
                    {
                        // Log a failure or output message
                        return false;
                    }
                }
                catch
                {
                    // Log a failure or output message
                    return false;
                }

            }

            // Get generated thrust
            try
            {
                if(testThruster.GetThrustGenerated() != 24)
                {
                    // Log a failure or output message
                    return false;
                }
            }
            catch
            {
                return false;
            }

            // Nothing else made us fail, so it looks good
            return true;
        }

        
    }
}
