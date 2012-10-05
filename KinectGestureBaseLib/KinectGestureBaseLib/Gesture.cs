using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coding4Fun.Kinect.WinForm;
using Coding4Fun.Kinect.Common;
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
        protected abstract double getDelayTimeSeconds();    //implement the delay between when the kinect looks for a gesture.
        protected abstract bool isDoingGesture();           //implement the gesture by reading vectors... public so can be accessed from other gestures (overrides the DateTime lock to reuse code!)
        public virtual String getDescription() { return "Unnamed Gesture"; }    //strongly encouraged to override - With name and/or Description
        public bool timeDelayHasPassed()
        {
            if ((DateTime.Now - delayDateTime).TotalSeconds >= getDelayTimeSeconds()) return true;
            if (delayDateTime == new DateTime()) return true;
            return false;
        }
        //other useful functions
        protected static float getDistanceX(Vector one, Vector two) { return Math.Abs(one.X - two.X); }
        protected static float getDistanceY(Vector one, Vector two) { return Math.Abs(one.Y - two.Y); }
        protected static float getDistanceZ(Vector one, Vector two) { return Math.Abs(one.Z - two.Z); }
    }
}
