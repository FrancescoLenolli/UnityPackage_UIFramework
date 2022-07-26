using Lerp;
using Tween.Animators.Base;
using Tween.Extensions;
using UnityEngine;

namespace Tween.Animators
{
    public class AnimatorRotation : LerpFloatAnimator
    {
        [SerializeField] private float startValue = 0f;
        [SerializeField] private float endValue = 360f;
        [SerializeField] private Axis rotationAxis = Axis.X;
        [SerializeField] private float time = 1f;
        [SerializeField] private Transform target = null;
        [SerializeField] private AnimationCurve animationCurve = null;

        public override void Init()
        {
            if (lerp == null)
            {
                lerp = LerpFloat.Basic;
                if (!target)
                {
                    target = transform;
                }
            }
        }

        public override void Animate(bool loop = false)
        {
            StartAnimation(loop, time, SetRotation, false);
        }

        private void SetRotation(float value)
        {
            target.SetSingleAngle(rotationAxis, animationCurve.Evaluate(value) * endValue);
        }
    }
}