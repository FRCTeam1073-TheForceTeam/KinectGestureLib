This project contains a set of classes that facilitates the process of writing and integrating Kinect gestures into a C# application.
This project provides an abstract Gesture class that statically contains protected Vector data from the NUI, to allow subclasses to have the ability to easily write gestures without having to worry about the API. Additionally, you can integrate Gestures easily into your application, with inherited methods from Gesture.cs that allow gestures to only be looked for after a fixed time period, and a simple abstract boolean method to determine if the Gesture is being performed. Finally, implementations of Gesture can be dynamically created and distinguished in application with a built in virtual String function in gesture to provide an ID of sorts (for those who want to use it) 

Contained in this repository is:
Microsoft.Research.Kinect.dll	- Windows DLL for Kinect API
Gesture.cs - Base class
/Gestures - Directory with example implementations of Gestures demonstrating the utilization of Gesture.cs and how to link Gestures together.
