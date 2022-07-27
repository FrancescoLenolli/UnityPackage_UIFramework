using Lerp;
using System;
using Tween.Animators.Base;
using Tween.Extensions;
using UnityEngine;

namespace Tween.Animators
{
    public class AnimatorTransformSingleValue : LerpFloatAnimator
    {
        private enum TransformProperty { Position, Rotation, Scale };

        [SerializeField] private Transform target = null;
        [Tooltip("Use this Transform's targetAxis as an end value" +
            "if you want to move the target position." +
            " Leave this NULL to use the field endValue to modify its position instead.")]
        [SerializeField] private Transform targetPosition = null;
        [SerializeField] private TransformProperty targetProperty = TransformProperty.Position;
        [SerializeField] private Axis targetAxis = Axis.X;
        [SerializeField] private float startValue = 0f;
        [SerializeField] private float endValue = 360f;
        [Tooltip("Total animation time.")]
        [SerializeField] private float time = 1f;
        [Tooltip("Customize the look of the Animation.")]
        [SerializeField] private AnimationCurve animationCurve = null;

        private Action<float> onAnimate = null;

        public override void Init()
        {
            InitData();

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
            StartAnimation(loop, time, onAnimate, false);
        }

        private void InitData()
        {
            switch (targetProperty)
            {
                case TransformProperty.Position:
                    onAnimate += SetPosition;
                    break;
                case TransformProperty.Rotation:
                    onAnimate += SetRotation;
                    break;
                case TransformProperty.Scale:
                    onAnimate += SetScale;
                    break;
                default:
                    break;
            }

            if (!targetPosition)
                return;

            switch (targetAxis)
            {
                case Axis.X:
                    endValue = targetPosition.position.x;
                    break;
                case Axis.Y:
                    endValue = targetPosition.position.y;
                    break;
                case Axis.Z:
                    endValue = targetPosition.position.z;
                    break;
                default:
                    break;
            }
        }

        private void SetRotation(float value)
        {
            target.SetSingleAngle(targetAxis, animationCurve.Evaluate(value) * endValue);
        }

        private void SetScale(float value)
        {
            target.SetSingleScale(targetAxis, animationCurve.Evaluate(value) * endValue);
        }

        private void SetPosition(float value)
        {
            target.SetSinglePosition(targetAxis, animationCurve.Evaluate(value) * endValue);
        }
    }
}