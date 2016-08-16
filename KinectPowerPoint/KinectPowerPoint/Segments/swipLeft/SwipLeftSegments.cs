using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Gestures;
namespace Gestures.Segments.swipLeft
{
    /// <summary>
    /// Z轴：右手在右肘的前方
    /// Y轴：右手的高度介于肩部和臀部之间
    /// X轴：右手在右肩的右侧
    /// </summary>
    public class SwipLeftSegment1:IRelativeGestureSegment
    {
        public GesturePartialResult CheckGesture(Body body)
        {
            Joint rightHand = body.Joints[JointType.HandRight];
            Joint rightShoulder = body.Joints[JointType.ShoulderRight];
            Joint rightHip= body.Joints[JointType.HipRight];
            Joint rightElbow=body.Joints[JointType.ElbowRight];

            //Z轴
            if(rightHand.Position.Z<rightElbow.Position.Z)
            {
                //Y
                if (rightHand.Position.Y > rightElbow.Position.Y)
                {
                    //X
                    if(rightHand.Position.X>rightShoulder.Position.X)
                    {
                        return GesturePartialResult.Suceed;
                    }
                    return GesturePartialResult.Undetermined;
                }
                return GesturePartialResult.Fail;
            }
            return GesturePartialResult.Fail;

        }        
    }

    /// <summary>
    /// Z:右手位于右肩前
    /// Y：肩部与臀部之间
    /// X：两肩之间
    /// </summary>
    public class SwipLeftSegment2 : IRelativeGestureSegment
    {
        public GesturePartialResult CheckGesture(Body body)
        {
            Joint rightHand = body.Joints[JointType.HandRight];
            Joint rightShoulder = body.Joints[JointType.ShoulderRight];
            Joint rightHip = body.Joints[JointType.HipRight];
            Joint rightElbow = body.Joints[JointType.ElbowRight];
            Joint leftShoulder = body.Joints[JointType.ShoulderLeft];
            //Z轴
            if (rightHand.Position.Z < rightElbow.Position.Z )
            {
                //Y
                if (rightHand.Position.Y > rightElbow.Position.Y)
                {
                    //X
                    if (rightHand.Position.X < rightShoulder.Position.X&&rightHand.Position.X>leftShoulder.Position.X)
                    {
                        return GesturePartialResult.Suceed;
                    }
                    return GesturePartialResult.Undetermined;
                }
                return GesturePartialResult.Fail;
            }
            return GesturePartialResult.Fail;
        }
    }

    /// <summary>
    /// Z:右手位于右肩前
    /// Y：肩部与臀部之间
    /// X：两肩之间
    /// </summary>
    public class SwipLeftSegment3 : IRelativeGestureSegment
    {
        public GesturePartialResult CheckGesture(Body body)
        {
            Joint rightHand = body.Joints[JointType.HandRight];
            Joint rightShoulder = body.Joints[JointType.ShoulderRight];
            Joint rightHip = body.Joints[JointType.HipRight];
            Joint rightElbow = body.Joints[JointType.ElbowRight];
            Joint leftShoulder = body.Joints[JointType.ShoulderLeft];
            Joint midHip = body.Joints[JointType.SpineBase];
            //Z轴
            if (rightHand.Position.Z < rightElbow.Position.Z )
            {
                //Y
                if (rightHand.Position.Y > rightElbow.Position.Y)
                {
                    //X
                    if (rightHand.Position.X > leftShoulder.Position.X)
                    {
                        return GesturePartialResult.Suceed;
                    }
                    return GesturePartialResult.Undetermined;
                }
                return GesturePartialResult.Fail;
            }
            return GesturePartialResult.Fail;
        }
    }
}
