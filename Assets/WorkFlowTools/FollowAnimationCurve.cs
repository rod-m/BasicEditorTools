using UnityEngine;
using System.Collections;
namespace WorkFlowTools
{
   

    public class FollowAnimationCurve : MonoBehaviour
    {
        public AnimationCurve curveX;
        public AnimationCurve curveY;
        public AnimationCurve curveZ;

        public void SetCurves(AnimationCurve xC, AnimationCurve yC, AnimationCurve zC)
        {
            curveX = xC;
            curveY = yC;
            curveZ = zC;
        }

        void Update()
        {
            transform.position = new Vector3(curveX.Evaluate(Time.time), curveY.Evaluate(Time.time), curveZ.Evaluate(Time.time));
        }
    }
}