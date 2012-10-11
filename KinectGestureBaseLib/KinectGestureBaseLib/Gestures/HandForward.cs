using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace KinectGestureBase.Gestures
{
    class HandForward : Gesture
    {
        bool leftHand;
        public HandForward(bool leftHand) { this.leftHand = leftHand; }
        protected override double getDelayTimeSeconds() { return 1.5; }
        public override bool isDoingGesture()
        {
            const float Z_THRESHOLD = 0.45f;
            return getDistanceZ(leftHand ? HAND_LEFT : HAND_RIGHT, SHOULDER_CENTER) >= Z_THRESHOLD;
        }
        public override string getDescription()
        {
            return "Sees if the " + (leftHand ? "left" : "right") + " hand is extended towards the Kienct";
        }
    }
}