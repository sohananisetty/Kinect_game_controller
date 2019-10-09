//------------------------------------------------------------------------------
// <copyright file="GestureResultView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.ContinuousGestureBasics
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    using Microsoft.Samples.Kinect.ContinuousGestureBasics.Common;

    /// <summary>
    /// Tracks gesture results coming from the GestureDetector and displays them in the UI.
    /// Updates the SpaceView object with the latest gesture result data from the sensor.
    /// </summary>
    public sealed class GestureResultView : BindableBase
    {
       
        private bool keepStraight = false;

        /// <summary> True, if the user is jumping </summary
        private bool jumpUp = false;

       
        /// <summary> True, if the body is currently being tracked </summary>
        private bool isTracked = false;

        /// <summary> SpaceView object in UI which has a spaceship that needs to be updated when we get new gesture results from the sensor </summary>
        //private SpaceView spaceView = null;

        /// <summary>
        /// Initializes a new instance of the GestureResultView class and sets initial property values
        
        public GestureResultView(bool isTracked,  bool straight,bool jump)
        {
            

            this.IsTracked = isTracked;
           
            this.KeepStraight = straight;
            this.JumpUp = jump;
           // this.SteerProgress = progress;
            //this.spaceView = space;
        }

        /// <summary> 
        /// Gets a value indicating whether or not the body associated with the gesture detector is currently being tracked 
        /// </summary>
        public bool IsTracked
        {
            get
            {
                return this.isTracked;
            }

            private set
            {
                this.SetProperty(ref this.isTracked, value);
            }
        }

        /// <summary> 
        /// Gets a value indicating whether the user is attempting to turn the ship left 
        /// </summary>
        

        /// <summary> 
        /// Gets a value indicating whether the user is trying to keep the ship straight
        /// </summary>
        public bool KeepStraight
        {
            get
            {
                return this.keepStraight;
            }

            private set
            {
                this.SetProperty(ref this.keepStraight, value);
            }
        }

        public bool JumpUp
        {
            get
            {
                return this.jumpUp;
            }

            private set
            {
                this.SetProperty(ref this.jumpUp, value);
            }
        }

        /// <summary> 
        /// Gets a value indicating the progress associated with the 'SteerProgress' gesture for the tracked body 
        /// </summary>
        

        /// <summary>
        /// Updates gesture detection result values for display in the UI
        /// </summary>
       
        public void UpdateGestureResult(bool isBodyTrackingIdValid, bool straight,bool jump)
        {
            this.IsTracked = isBodyTrackingIdValid;

            if (!this.isTracked)
            {
                
                this.KeepStraight = false;
                this.JumpUp = false;
               
            }
            else
            {
               
                this.KeepStraight = straight;
                this.JumpUp = jump;
               
            }

           
        }
    }
}
