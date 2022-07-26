using Lerp;
using System.Collections;
using Tween.Animators.Base;
using UnityEngine;

namespace Tween.Animators
{
    public class AnimatorTransform : LerpVectorAnimator
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private Transform start = null;
        [SerializeField] private Transform end = null;
        [SerializeField] private float time = 1f;

        private Vector3 startPosition;
        private Vector3 endPosition;

        public override void Init()
        {
            if (lerp == null)
            {
                startPosition = start ? start.position : target.position;
                endPosition = end.position;
                lerp = new LerpVector(startPosition, endPosition, true);
            }
        }

        public override void Animate(bool loop = false)
        {
            if (!target || !end)
            {
                Debug.Log($"Animator in {name} has no Target or End set!");
                return;
            }

            if (loop)
            {
                StartAnimation(LoopRoutine(time));
            }
            else
            {
                StartAnimation(LerpRoutine(time));
            }
        }

        private IEnumerator LerpRoutine(float time)
        {
            canAnimate = false;

            while (!lerp.Evaluate(Time.deltaTime, time))
            {
                target.position = lerp.Value;
                yield return null;
            }

            target.position = lerp.Value;
            canAnimate = true;
        }

        private IEnumerator LoopRoutine(float time)
        {
            while (true)
            {
                if (!lerp.Evaluate(Time.deltaTime, time))
                {
                    target.position = lerp.Value;
                }
                else
                {
                    target.position = lerp.Value;
                    lerp.Reset();
                    lerp.Reverse();
                }

                yield return null;
            }
        }
    }
}