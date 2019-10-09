//------------------------------------------------------------------------------
// <copyright file="GestureDetector.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.ContinuousGestureBasics
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Kinect;
    using Microsoft.Kinect.VisualGestureBuilder;
    using InputManager;
    using System.Diagnostics;
    using System.IO;
    using System.Text; 

    /// <summary>
    /// Gesture Detector class which polls for VisualGestureBuilderFrames from the Kinect sensor
    /// Updates the associated GestureResultView object with the latest gesture results
    /// </summary>
    public sealed class GestureDetector : IDisposable
    {
        /// <summary> Path to the gesture database that was trained with VGB </summary>
        private readonly string gestureDatabase = @"Database\discrete_actions.gbd";

       
        private readonly string StraightGestureName = "run";
        

        private readonly string jumpGestureName = "jumpv2";

       
        private VisualGestureBuilderFrameSource vgbFrameSource = null;

        /// <summary> Gesture frame reader which will handle gesture events coming from the sensor </summary>
        private VisualGestureBuilderFrameReader vgbFrameReader = null;

        /// <summary>
        /// Initializes a new instance of the GestureDetector class along with the gesture frame source and reader
        /// </summary>
        /// <param name="kinectSensor">Active sensor to initialize the VisualGestureBuilderFrameSource object with</param>
        /// <param name="gestureResultView">GestureResultView object to store gesture results of a single body to</param>
        public GestureDetector(KinectSensor kinectSensor, GestureResultView gestureResultView)
        {
            if (kinectSensor == null)
            {
                throw new ArgumentNullException("kinectSensor");
            }

            if (gestureResultView == null)
            {
                throw new ArgumentNullException("gestureResultView");
            }
            
            this.GestureResultView = gestureResultView;
            //this.ClosedHandState = false;
            
            // create the vgb source. The associated body tracking ID will be set when a valid body frame arrives from the sensor.
            this.vgbFrameSource = new VisualGestureBuilderFrameSource(kinectSensor, 0);

            // open the reader for the vgb frames
            this.vgbFrameReader = this.vgbFrameSource.OpenReader();
            if (this.vgbFrameReader != null)
            {
                this.vgbFrameReader.IsPaused = true;
            }

            // load all gestures from the gesture database
            using (var database = new VisualGestureBuilderDatabase(this.gestureDatabase))
            {
                this.vgbFrameSource.AddGestures(database.AvailableGestures);
            }
           
        }

        /// <summary> 
        /// Gets the GestureResultView object which stores the detector results for display in the UI 
        /// </summary>
        public GestureResultView GestureResultView { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the body associated with the detector has at least one hand closed
        /// </summary>
       // public bool ClosedHandState { get; set; }

        /// <summary>
        /// Gets or sets the body tracking ID associated with the current detector
        /// The tracking ID can change whenever a body comes in/out of scope
        /// </summary>
        public ulong TrackingId
        {
            get
            {
                return this.vgbFrameSource.TrackingId;
            }

            set
            {
                if (this.vgbFrameSource.TrackingId != value)
                {
                    this.vgbFrameSource.TrackingId = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the detector is currently paused
        /// If the body tracking ID associated with the detector is not valid, then the detector should be paused
        /// </summary>
        public bool IsPaused
        {
            get
            {
                return this.vgbFrameReader.IsPaused;
            }

            set
            {
                if (this.vgbFrameReader.IsPaused != value)
                {
                    this.vgbFrameReader.IsPaused = value;
                }
            }
        }

        /// <summary>
        /// Retrieves the latest gesture detection results from the sensor
        /// </summary>
        public void UpdateGestureData()
        {
            using (var frame = this.vgbFrameReader.CalculateAndAcquireLatestFrame())
            {
                if (frame != null)
                {
                    // get all discrete and continuous gesture results that arrived with the latest frame
                    var discreteResults = frame.DiscreteGestureResults;
                    //var continuousResults = frame.ContinuousGestureResults;

                    if (discreteResults != null)
                    {
                       
                        bool keepStraight = this.GestureResultView.KeepStraight;
                        bool jumpUp = this.GestureResultView.JumpUp;
                        
 
                        foreach (var gesture in this.vgbFrameSource.Gestures)
                        {
                            if (gesture.GestureType == GestureType.Discrete)
                            {
                                DiscreteGestureResult result = null;
                                discreteResults.TryGetValue(gesture, out result);

                                if (result != null)
                                {
                                    
                                     if (gesture.Name.Equals(this.StraightGestureName))
                                    {
                                        keepStraight = result.Detected;
                                    }
                                    else if (gesture.Name.Equals(this.jumpGestureName))
                                    {
                                        jumpUp = result.Detected;
                                    }
                                 
                                }
                            }

                          
                        }

                       
                        if (jumpUp)
                        {
                            jumpUp = true;
                           
                            var psi = new ProcessStartInfo();
                            psi.FileName = @"C:\Users\soboy\Anaconda3\python.exe";

                            // 2) Provide script and arguments
                            var script = @"C:\Users\soboy\Documents\project_Kinect\Kinect_Game_controller\keyboard.py";
                            var key1 = "S";
                            var key2 = "S";

                            psi.Arguments = $"\"{script}\" \"{key1}\" \"{key2}\"";

                            // 3) Process configuration
                            psi.UseShellExecute = false;
                            psi.CreateNoWindow = true;
                            psi.RedirectStandardOutput = true;
                            psi.RedirectStandardError = true;

                            // 4) Execute process and get output
                            var errors = "";
                            var results = "";

                            using (var process = Process.Start(psi))
                            {
                                errors = process.StandardError.ReadToEnd();
                                results = process.StandardOutput.ReadToEnd();
                            }
                        }

                        
                        if (keepStraight)
                        {
                            keepStraight = true;
                           
                            
                            var psi = new ProcessStartInfo();
                            psi.FileName = @"C:\Users\soboy\Anaconda3\python.exe";

                            // 2) Provide script and arguments
                            var script = @"C:\Users\soboy\Documents\project_Kinect\Kinect_Game_controller\keyboard.py";
                            var key1 = "W";
                            var key2 = "W";

                            psi.Arguments = $"\"{script}\" \"{key1}\" \"{key2}\"";

                            // 3) Process configuration
                            psi.UseShellExecute = false;
                            psi.CreateNoWindow = true;
                            psi.RedirectStandardOutput = true;
                            psi.RedirectStandardError = true;

                            // 4) Execute process and get output
                            var errors = "";
                            var results = "";

                            using (var process = Process.Start(psi))
                            {
                                errors = process.StandardError.ReadToEnd();
                                results = process.StandardOutput.ReadToEnd();
                            }
                            
                        }


                        // update the UI with the latest gesture detection results
                        this.GestureResultView.UpdateGestureResult(true,keepStraight,jumpUp);
                    }
                }
            }
        }

        /// <summary>
        /// Disposes the VisualGestureBuilderFrameSource and VisualGestureBuilderFrameReader objects
        /// </summary>
        public void Dispose()
        {
            if (this.vgbFrameReader != null)
            {
                this.vgbFrameReader.Dispose();
                this.vgbFrameReader = null;
            }

            if (this.vgbFrameSource != null)
            {
                this.vgbFrameSource.Dispose();
                this.vgbFrameSource = null;
            }
        }
    }
}
