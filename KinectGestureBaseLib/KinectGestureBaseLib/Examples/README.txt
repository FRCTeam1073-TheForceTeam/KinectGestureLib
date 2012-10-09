The files in this directory contain a utilization of Gesture.cs
To use the class, simply:
	1.) scan the Kinect Runtime NUI
	2.) update the static Vectors in Gesture.cs with the NUI data in void UpdateJoints(SkeletonData data)
	3.) Create private variables for each Gesture you want to scan. Construct them.
		If your computer is fast enough, put them all in an array and do the DateTime and Gesture validation in a loop traversal below (efficient)
		Just be careful that if computer IS NOT fast enough, you'll be stuck parsing gestures on dated NUI input (very bad).
	4.) in the NUI scanning logic, check for timeDelayHasPassed() on each Gesture.
	5.) if that's true, check for isDoingGesture() on each gesture.
	6.) run the appropriate code if your gesture is validaed. In my exmaple I display getInfo() in a MessageBox on each passed Gesture...