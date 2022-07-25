using System;
using System.Collections;
using UnityEngine;

public abstract class LerpFloatAnimator : LerpAnimatorBase
{
    protected LerpFloat lerp;

    protected void StartAnimation(bool loop, float time, Action<float> action, bool reverse = true)
    {
        if (loop)
        {
            StartAnimation(LoopRoutine(time, action, reverse));
        }
        else
        {
            StartAnimation(LerpRoutine(time, action));
        }
    }

    private void StartAnimation(IEnumerator animation)
    {
        Init();

        if (canAnimate)
        {
            if (lerp.IsComplete)
            {
                lerp.Reset();
                lerp.Reverse();
            }
            StartCoroutine(animation);
        }
    }

    private IEnumerator LerpRoutine(float time, Action<float> action)
    {
        canAnimate = false;

        while (!lerp.Evaluate(Time.deltaTime, time))
        {
            action?.Invoke(lerp.Value);
            yield return null;
        }

        action?.Invoke(lerp.Value);
        canAnimate = true;
    }

    private IEnumerator LoopRoutine(float time, Action<float> action, bool reverse)
    {
        while (true)
        {
            if (!lerp.Evaluate(Time.deltaTime, time))
            {
                action(lerp.Value);
            }
            else
            {
                action(lerp.Value);
                lerp.Reset();
                if (reverse)
                {
                    lerp.Reverse();
                }
            }

            yield return null;
        }
    }
}
