using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarsLander
{
    class RollThruster
    {
        // Duration of thrust to begin/end correction
        private int thrustDuration;
        // How long after starting corrective thrust do we need to wait to start canceling thrust per 1* of rotation
        private double secondsOfCorrectiveThrust;
        // How long we need to fire the engine to negate 1 rotation per minute of rotation
        private double secondsOfRollCorrectionThrust;
        // Throttle state of the engine, -1 to +1 (throttle in one direction or the other)
        private double throttle;

        public RollThruster()
        {
            thrustDuration = 1;
            secondsOfCorrectiveThrust = .2;
            secondsOfRollCorrectionThrust = .1;
            throttle = 0;
        }

        // rollDelta is the number of degrees from targetted attitude that we need to correct for, this can be positive or negative depending on direction
        public double calcCorrectiveThrustDuration(double rollDelta)
        {
            return Math.Abs(rollDelta * secondsOfCorrectiveThrust);
        }

        // rollDelta is the number of degrees from targetted attitude that we need to correct for, this can be positive or negative depending on direction
        public double applyRollCorrection(double rollDelta)
        {
            double correctiveDuration = calcCorrectiveThrustDuration(rollDelta);

            if(rollDelta == 0)
            {
                // No corrective actions needed
                Debug.WriteLine("No correction needed");
                return 0;
            }

            // Fire thrusters in appropriate direction;
            if(rollDelta < 0)
            {
                throttle = -1;
            }
            else if(rollDelta > 0)
            {
                throttle = 1;
            }
            else
            {
                throttle = 0;
            }
            Debug.WriteLine("Throttle: " + throttle);
            System.Threading.Thread.Sleep(thrustDuration * 1000);
            throttle = 0;
            Debug.WriteLine("Throttle: " + throttle);
            System.Threading.Thread.Sleep((int)(correctiveDuration * 1000));
            Debug.WriteLine("CorrectiveDuration: " + (int)(correctiveDuration * 1000));
            // Fire thrusters in opposite direction to finalize rotation;
            if (rollDelta < 0)
            {
                throttle = 1;
            }
            else if (rollDelta > 0)
            {
                throttle = -1;
            }
            else
            {
                throttle = 0;
            }
            Debug.WriteLine("Throttle: " + throttle);
            System.Threading.Thread.Sleep(thrustDuration * 1000);
            throttle = 0;
            Debug.WriteLine("Throttle: " + throttle);

            return correctiveDuration;
        }

        // currentSpin = current spin rate in rotations per minute, -x to +x where thrust will counter accordingly
        public double correctCurrentSpin(double currentSpin)
        {
            double correctionToApply = Math.Abs(currentSpin * secondsOfRollCorrectionThrust);

            if (correctionToApply == 0)
            {
                // No corrective actions needed
                Debug.WriteLine("No correction needed");
                return 0;
            }

            if (correctionToApply < 0)
            {
                throttle = -1;
            }
            else if (correctionToApply > 0)
            {
                throttle = 1;
            }
            else
            {
                throttle = 0;
            }
            Debug.WriteLine("SpinCorrection Throttle: " + throttle);
            Debug.WriteLine("SpinCorrection Time: " + (correctionToApply * 1000));
            System.Threading.Thread.Sleep((int)(correctionToApply * 1000));
            throttle = 0;
            Debug.WriteLine("SpinCorrection Throttle: " + throttle);

            return correctionToApply;
        }

        public bool SelfTest()
        {
            /* Test cases to test against:
                RollCorrection
                - 0 roll delta = 0 total corrective duration, and no firing
                - 1 roll delta = turn on engines, apply .2 seconds of corrective wait
                - -1 roll deltr = turn on engines to -1, apply .2 seconds of corrective wait
                - 10 roll delta = turn engines on to 1, apply 2 seconds of corrective wait
                - -10 roll delta = turn engines on to -1, apply 2 seconds of corrective wait

                correctSpin
                - 0 roll  = 0 total corrective duration, and no firing
                - 1 rpm  = turn on engines, apply .1 seconds of corrective wait
                - -1 rpm  = turn on engines to -1, apply .1 seconds of corrective wait
                - 10 rpm  = turn engines on to 1, apply 1 seconds of corrective wait
                - -10 rpm  = turn engines on to -1, apply 1 seconds of corrective wait
            */
            bool returnVal = true;
            RollThruster testThruster = new RollThruster();

            if (returnVal == true)
            {
                returnVal = (testThruster.applyRollCorrection(0) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.applyRollCorrection(1) == .2);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.applyRollCorrection(-1) == .2);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.applyRollCorrection(10) == 2);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.applyRollCorrection(-10) == 2);
            }



            if (returnVal == true)
            {
                returnVal = (testThruster.correctCurrentSpin(0) == 0);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.correctCurrentSpin(1) == .1);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.correctCurrentSpin(-1) == .1);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.correctCurrentSpin(10) == 1);
            }
            if (returnVal == true)
            {
                returnVal = (testThruster.correctCurrentSpin(-10) == 1);
            }

            return returnVal;
        }
    }
}
