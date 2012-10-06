//simple extension off of Gesture.cs to see if legs are spread. you can take pass in a threshold, or construct using a default

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinectGestureBase.Gestures
{
    class SpreadLegs : Gesture
    {
        private const float DEFAULT_DISTANCE = 0.55f;
        private float spreadDistance;
        public SpreadLegs() { spreadDistance = DEFAULT_DISTANCE; }
        public SpreadLegs(float spreadDistance) { this.spreadDistance = spreadDistance; }
        protected override double getDelayTimeSeconds() { return 1.0; }
        public override string getDescription()
        {
            return "Gesture that sees if legs are spread by " + spreadDistance + " meters";
        }
        public override bool isDoingGesture()
        {
            return getDistanceX(KNEE_LEFT, KNEE_RIGHT) >= spreadDistance;
        }
       
    }
}
