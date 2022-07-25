using Lerp;
using Tween.Animators.Base;
using Tween.Extensions;
using UnityEngine;

namespace Tween.Animators
{
    public class AnimatorScale : LerpFloatAnimator
    {
        [SerializeField] private float startValue = 0f;
        [SerializeField] private float endValue = 0f;
        [SerializeField] private float time = 1f;
        [SerializeField] private Axis scaleAxis = Axis.X;
        [SerializeField] private Transform target = null;

        public override void Init()
        {
            if (lerp == null)
            {
                lerp = new LerpFloat(startValue, endValue);
            }
        }

        public override void Animate(bool loop = false)
        {
            if (!target)
            {
                Debug.Log($"Animator in {name} has no Target set!");
                return;
            }

            StartAnimation(loop, time, SetScale);
        }

        private void SetScale(float value)
        {
            target.SetSingleScale(scaleAxis, value);
        }
    }
}