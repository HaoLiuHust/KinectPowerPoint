using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestures
{
    using Microsoft.Kinect;
    public interface IRelativeGestureSegment
    {
        GesturePartialResult CheckGesture(Body body);
    }
}
