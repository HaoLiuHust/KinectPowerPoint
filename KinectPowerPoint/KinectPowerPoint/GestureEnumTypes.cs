using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestures
{
    public enum GesturePartialResult
    {
        Fail,
        Suceed,
        Undetermined
    }
    public enum GestureTypes
    {
        None,
        JointdHands,
        WaveRight,
        WaveLeft,
        Menu,
        SwipeLeft,
        SwipeRight,
        ZoomIn,
        ZoomOut
    }
}
