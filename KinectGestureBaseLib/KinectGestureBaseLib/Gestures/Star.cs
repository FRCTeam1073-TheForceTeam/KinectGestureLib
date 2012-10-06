/*extension off of Gesture.cs to see if people are in a star shape. This class utilies some of the other gestures by bypassing 
 *the datetime restriction.
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinectGestureBase.Gestures
{
    class Star : Gesture
    {
        public Star() { }
        protected override double getDelayTimeSeconds() { return 2.0; }
        public override bool isDoingGesture()
        {
            if (getDistanceZ(HAND_LEFT, HAND_RIGHT) > 0.15f) return false;  //hands should be paralell in z plane.
            if (!new SpreadLegs().isDoingGesture()) return false;
            if (!new ArmsExtended().isDoingGesture()) return false;
            return true;
        }
        public override string getDescription() { return "Star shaped function that demonstrates utilization of other gestures"; }
    }
}
