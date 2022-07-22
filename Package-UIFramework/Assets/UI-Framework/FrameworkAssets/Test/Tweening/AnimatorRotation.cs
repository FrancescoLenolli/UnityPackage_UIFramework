using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRotation : AnimatorBase
{
    [SerializeField] private float startValue = 0f;
    [SerializeField] private float endValue = 360f;
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
            StartCoroutine(LoopRoutine(time));
        }
    }

    private IEnumerator LerpRoutine(float time)
    {
        canAnimate = false;
        float newRotation = 0f;

        while (!lerp.Evaluate(Time.deltaTime, time))
        {
            newRotation = lerp.Value;
            target.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, target.rotation.eulerAngles.y, newRotation);
            yield return null;
        }

        newRotation = lerp.Value;
        target.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, target.rotation.eulerAngles.y, newRotation);
        canAnimate = true;
    }

    private IEnumerator LoopRoutine(float time)
    {
        float newRotation = 0f;

        while (true)
        {
            if (!lerp.Evaluate(Time.deltaTime, time, false))
            {
                newRotation = -lerp.Value;
                target.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, target.rotation.eulerAngles.y, newRotation);
            }
            else
            {
                newRotation = -lerp.Value;
                target.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, target.rotation.eulerAngles.y, newRotation);
                lerp.Reset();
            }

            yield return null;
        }
    }
}
