//simple extension of Gesture.cs to see if arms are extended

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KinectGestureBase;
namespace KinectGestureBase.Gestures
{
    class ArmsExtended : Gesture
    {
        public ArmsExtended() { }
        protected override double getDelayTimeSeconds()
        {
            return 0.75;
        }
        public override bool isDoingGesture()
        {
            float x_threshold = 0.6f;
            float y_threshold = 0.1f;
            bool x = getDistanceX(HAND_LEFT, SHOULDER_LEFT) >= x_threshold && getDistanceX(HAND_RIGHT, SHOULDER_RIGHT) >+ x_threshold;
            bool y = getDistanceY(HAND_LEFT, HAND_RIGHT) <= y_threshold;    //make sure they're in a paralell y plane
            return x && y;
        }
        public override string getDescription()
        {
            return "Arms extended";
        }
    }
}
