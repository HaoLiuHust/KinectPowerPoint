using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestures.Segments.swipLeft;
using Gestures.Segments.swipRight;
using Microsoft.Kinect;
namespace Gestures
{
    class GestureController
    {
        private List<Gesture> gestures = new List<Gesture>();

        public GestureController()
        {
            IRelativeGestureSegment[] swipleftSegments = new IRelativeGestureSegment[3];
            swipleftSegments[0] = new SwipLeftSegment1();
            swipleftSegments[1] = new SwipLeftSegment2();
            swipleftSegments[2] = new SwipLeftSegment3();

            AddGesture(GestureTypes.SwipeLeft, swipleftSegments);

            IRelativeGestureSegment[] swiprightSegments = new IRelativeGestureSegment[3];
            swiprightSegments[0] = new SwipRightSegment1();
            swiprightSegments[1] = new SwipRightSegment2();
            swiprightSegments[2] = new SwipRightSegment3();

            AddGesture(GestureTypes.SwipeRight, swiprightSegments);
        }

        public event EventHandler<GestureEventArgs> GestureRecognized;

        public void UpdateAllGestures(Body body)
        {
            foreach(Gesture g in this.gestures)
            {
                g.UpdateGesture(body);
            }
        }

        public void AddGesture(GestureTypes type,IRelativeGestureSegment[] gestureDefinition)
        {
            Gesture gesture = new Gesture(type, gestureDefinition);
            gesture.GestureDetected += gesture_GestureDetected;
            this.gestures.Add(gesture);
        }


        void gesture_GestureDetected(object sender, GestureEventArgs e)
        {
            if(this.GestureRecognized!=null)
            {
                this.GestureRecognized(this, e);
            }

            foreach(Gesture g in gestures)
            {
                g.Reset();
            }
        }
    }
}
