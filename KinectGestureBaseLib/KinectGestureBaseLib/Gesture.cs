using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Research.Kinect.Nui;
namespace KinectGestureBase
{
    public abstract class Gesture
    {
        #region joints
        static protected Vector HEAD;
        static protected Vector SPINE;
        static protected Vector SHOULDER_LEFT, SHOULDER_CENTER, SHOULDER_RIGHT;
        static protected Vector ELBOW_LEFT, ELBOW_RIGHT;
        static protected Vector WRIST_LEFT, WRIST_RIGHT;
        static protected Vector HAND_LEFT, HAND_RIGHT;
        static protected Vector HIP_LEFT, HIP_CENTER, HIP_RIGHT;
        static protected Vector KNEE_LEFT, KNEE_RIGHT;
        static protected Vector ANKLE_LEFT, ANKLE_RIGHT;
        static protected Vector FOOT_LEFT, FOOT_RIGHT;
        #endregion 
        #region useful constants
        protected static const float FIVE_INCHES = 1.27f;
        #endregion
        static public void updateJoints(SkeletonData data)
        {
            HEAD = data.Joints[JointID.Head].Position;
            SPINE = data.Joints[JointID.Spine].Position;
            SHOULDER_LEFT = data.Joints[JointID.ShoulderLeft].Position;
            SHOULDER_CENTER = data.Joints[JointID.ShoulderCenter].Position;
            SHOULDER_RIGHT = data.Joints[JointID.ShoulderRight].Position;
            ELBOW_LEFT = data.Joints[JointID.ElbowLeft].Position;
            ELBOW_RIGHT = data.Joints[JointID.ElbowRight].Position;
            WRIST_LEFT = data.Joints[JointID.WristLeft].Position;
            WRIST_RIGHT = data.Joints[JointID.WristRight].Position;
            HAND_LEFT = data.Joints[JointID.HandLeft].Position;
            HAND_RIGHT = data.Joints[JointID.HandRight].Position;
            HIP_LEFT = data.Joints[JointID.HipLeft].Position;
            HIP_CENTER = data.Joints[JointID.HipCenter].Position;
            HIP_RIGHT = data.Joints[JointID.HipRight].Position;
            KNEE_LEFT = data.Joints[JointID.KneeLeft].Position;
            KNEE_RIGHT = data.Joints[JointID.KneeRight].Position;
            ANKLE_LEFT = data.Joints[JointID.AnkleLeft].Position;
            ANKLE_RIGHT = data.Joints[JointID.AnkleRight].Position;
            FOOT_LEFT = data.Joints[JointID.FootLeft].Position;
            FOOT_RIGHT = data.Joints[JointID.FootRight].Position;
        }
        protected DateTime delayDateTime = new DateTime();
        protected virtual double getDelayTimeSeconds() { return 1.0; }    //the delay between when the kinect looks for a gesture.
        public abstract bool isDoingGesture();           //implement the gesture by reading vectors... public so can be accessed from other gestures (overrides the DateTime lock to reuse code!)
        public virtual void updateGesture()             //override if you want to...
        {
            delayDateTime = DateTime.Now;
        }
        public virtual String getDescription() { return "Unnamed Gesture"; }    //strongly encouraged to override - With name and/or Description
        public bool timeDelayHasPassed()
        {
            return ((DateTime.Now - delayDateTime).TotalSeconds >= getDelayTimeSeconds() || delayDateTime == new DateTime());
        }
        //other useful functions
        protected static float getDistanceX(Vector one, Vector two) { return Math.Abs(one.X - two.X); }
        protected static float getDistanceY(Vector one, Vector two) { return Math.Abs(one.Y - two.Y); }
        protected static float getDistanceZ(Vector one, Vector two) { return Math.Abs(one.Z - two.Z); }
        protected static double get2DDistance(Vector one, Vector two)   
        {
            //kinect has vectors as floats. sqrt returns a double
            float x = two.X - one.X;
            float y = two.Y - one.Y;
            return Math.Sqrt((double)(x * x + y * y));
        }
        protected static double get3DDistance(Vector one, Vector two)
        {
            float x = two.X - one.X;
            float y = two.Y - one.Y;
            float z = two.Z - one.Z;
            return Math.Sqrt((double)(x * x + y * y + z * z));
        }
        protected static float getSlope(Vector one, Vector two)
        {
            float rise = two.Y - one.Y;
            float run = two.X - one.X;
            return rise / run;
        }
        protected static bool sameXPlane(Vector one, Vector two) { return getDistanceX(one, two) <= FIVE_INCHES; }
        protected static bool sameYPlane(Vector one, Vector two) { return getDistanceY(one, two) <= FIVE_INCHES; }
        protected static bool sameZPlane(Vector one, Vector two) { return getDistanceZ(one, two) <= FIVE_INCHES; }
        protected static bool isLeft(Vector one, Vector two)     { return one.X < two.X; }
        protected static bool isRight(Vector one, Vector two)    { return one.X > two.X; }
        protected static bool isBelow(Vector one, Vector two)    { return one.Y < two.Y; }
        protected static bool isAbove(Vector one, Vector two)    { return one.Y > two.Y; }
        protected static bool isBehind(Vector one, Vector two)   { return one.Z > two.Z; }
        protected static bool isFront(Vector one, Vector two)    { return one.Z < two.Z; }
        protected static bool touching(Vector one, Vector two)   {return touching(new Vector[] { one, two });}
        protected static bool touching(Vector[] joints)
        {
            if( joints.Length < 2) return false;
            for (int i = 1; i < joints.Length; i++)
            {
                Vector a = joints[i - 1], b = joints[i];
                bool test = sameXPlane(a, b) && sameYPlane(a, b) && sameZPlane(a, b);
                if (!test) return false;
            }
            return true;
        }
    }
}
