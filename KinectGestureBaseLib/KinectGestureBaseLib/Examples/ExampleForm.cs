//Example Form to utilize Gesture.cs. Refer to /Examples/README.txt for more information...
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Research.Kinect.Nui;
using KinectGestureBase.Gestures;
namespace KinectGestureBase.Examples
{
    public partial class ExampleForm : Form
    {
        private Runtime nui;
        private List<Gesture> gestures; //fill with gestures I want to look at...
        public ExampleForm()
        {
            nui = new Runtime();
            try
            {
                nui.Initialize(RuntimeOptions.UseSkeletalTracking | RuntimeOptions.UseColor); // Test for Kinect
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Runtime initialization failed. Please make sure the Kinect is plugged in and installed...");
                return;
            }
            nui.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(nui_SkeletonFrameReady);
            gestures = new List<Gesture>();
            gestures.Add(new HandForward(true));
            gestures.Add(new Star());
            InitializeComponent();
        }
        void nui_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            
            foreach (SkeletonData data in e.SkeletonFrame.Skeletons)
            {
                Gesture.updateJoints(data);
                foreach (Gesture gesture in gestures)
                {
                    if (gesture.timeDelayHasPassed())    //check for time delay.
                    {
                        if (gesture.isDoingGesture())   //check to see if the gesture is being performed.
                        {
                            //hey, the gesture is being performed. Go do some thing with it in your program...
                            MessageBox.Show(gesture.getDescription());  //In this example I just print the Gesture's description.
                            gesture.updateGesture();
                        }
                    }
                }
            }
        }
    }
}
