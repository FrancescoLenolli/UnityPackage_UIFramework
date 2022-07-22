using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScale : AnimatorBase
{
    [SerializeField] private float startValue = 0f;
    [SerializeField] private float endValue = 0f;
    [SerializeField] private float time = 1f;
    [SerializeField] private Transform target = null;

    private bool canAnimate = true;
    private LerpFloat lerp;

    public override void Init()
    {
        if (lerp == null)
        {
            lerp = new LerpFloat(startValue, endValue);
        }
    }

    public override void Animate()
    {
        Init();

        if (canAnimate)
        {
            if (lerp.IsComplete)
            {
                lerp.Reset();
                lerp.Reverse();
            }
            StartCoroutine(PingPongRoutine(time));
        }
    }

    private IEnumerator LerpRoutine(float time)
    {
        canAnimate = false;
        float newScale = 0f;

        while (!lerp.Evaluate(Time.deltaTime, time))
        {
            newScale = lerp.Value;
            target.localScale = new Vector3(target.localScale.x, newScale, target.localScale.z);
            yield return null;
        }

        newScale = lerp.Value;
        target.localScale = new Vector3(target.localScale.x, newScale, target.localScale.z);
        canAnimate = true;
    }

    private IEnumerator PingPongRoutine(float time)
    {
        float newScale = 0f;

        while (true)
        {
            if (!lerp.Evaluate(Time.deltaTime, time))
            {
                newScale = lerp.Value;
                target.localScale = new Vector3(target.localScale.x, newScale, target.localScale.z);
            }
            else
            {
                newScale = lerp.Value;
                target.localScale = new Vector3(target.localScale.x, newScale, target.localScale.z);
                lerp.Reset();
                lerp.Reverse();
            }

            yield return null;
        }
    }
}
