using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPosition : AnimatorBase
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Transform end = null;
    [SerializeField] private float time = 1f;

    private LerpVector lerp;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool canAnimate = true;

    public override void Init()
    {
        if (lerp == null)
        {
            startPosition = target.position;
            endPosition = end.position;
            lerp = new LerpVector(startPosition, endPosition);
        }
    }

    public override void Animate()
    {
        Init();
        canAnimate = true;

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

        while (!lerp.Evaluate(Time.deltaTime, time))
        {
            target.position = lerp.Value;
            yield return null;
        }

        target.position = lerp.Value;
        canAnimate = true;
    }

    private IEnumerator PingPongRoutine(float time)
    {
        while(true)
        {
            if(!lerp.Evaluate(Time.deltaTime, time, false))
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
