using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
namespace Gestures
{
    class Gesture
    {
        private IRelativeGestureSegment[] gestureParts;
        private int currentGesturePart = 0;
        private int pausedFrameCount = 10;
        private int frameCount = 0;
        private bool paused = false;
        private GestureTypes type;

        public Gesture(GestureTypes type,IRelativeGestureSegment[] gestureParts)
        {
            this.gestureParts = gestureParts;
            this.type = type;
        }

        public event EventHandler<GestureEventArgs> GestureDetected;

        public void UpdateGesture(Body body)
        {
            if(this.paused)
            {
                if(this.frameCount==this.pausedFrameCount)
                {
                    this.paused = false;
                }
                this.frameCount++;
            }

            GesturePartialResult result = this.gestureParts[this.currentGesturePart].CheckGesture(body);
            if(result==GesturePartialResult.Suceed)
            {
                if(currentGesturePart+1<gestureParts.Length)
                {
                    currentGesturePart++;
                    this.frameCount = 0;
                    this.pausedFrameCount = 10;
                    this.paused = true;
                }
                else
                {
                    if (this.GestureDetected != null)
                    {
                        GestureDetected(this, new GestureEventArgs(this.type, body.TrackingId));
                        Reset();
                    }
                }            
            }
            else if(result==GesturePartialResult.Fail||this.frameCount==50)
            {
                this.currentGesturePart = 0;
                this.frameCount = 0;
                this.pausedFrameCount = 5;
                this.paused = true;
            }
            else
            {
                this.frameCount++;
                this.pausedFrameCount = 5;
                this.paused = true;
            }
        }

        public void Reset()
        {
            currentGesturePart = 0;
            frameCount = 0;
            pausedFrameCount = 5;
            paused = true;
        }
    }
}
