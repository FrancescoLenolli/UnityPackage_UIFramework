using Lerp;
using Tween.Animators.Base;
using UnityEngine;

namespace Tween.Animators
{
    public class AnimatorCanvasGroup : LerpFloatAnimator
    {
        [SerializeField] private float startValue = 0f;
        [SerializeField] private float endValue = 0f;
        [SerializeField] private float time = 1f;
        [SerializeField] private CanvasGroup canvasGroup = null;

        public override void Init()
        {
            if (lerp == null)
            {
                lerp = new LerpFloat(startValue, endValue);
            }
        }

        public override void Animate(bool loop = false)
        {
            if (!canvasGroup)
            {
                Debug.Log($"Animator in {name} has no CanvasGroup set!");
                return;
            }

            StartAnimation(loop, time, SetAlpha);
        }

        private void SetAlpha(float value)
        {
            canvasGroup.alpha = value;
        }
    }
}