using System;
using System.Collections;
using UnityEngine;

public class LerpFloatAnimator : LerpAnimatorBase
{
    protected LerpFloat lerp;

    protected void StartAnimation(bool loop, float time, Action<float> action)
    {
        if (loop)
        {
            StartAnimation(LoopRoutine(time, action));
        }
        else
        {
            StartAnimation(LerpRoutine(time, action));
        }
    }

    protected void StartAnimation(IEnumerator animation)
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

    protected IEnumerator LerpRoutine(float time, Action<float> action)
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

    protected IEnumerator LoopRoutine(float time, Action<float> action)
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
                lerp.Reverse();
            }

            yield return null;
        }
    }
}
