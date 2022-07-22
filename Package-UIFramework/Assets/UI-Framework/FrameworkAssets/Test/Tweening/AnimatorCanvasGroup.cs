using System.Collections;
using UnityEngine;

public class AnimatorCanvasGroup : AnimatorBase
{
    [SerializeField] private float startValue = 0f;
    [SerializeField] private float endValue = 0f;
    [SerializeField] private float time = 1f;
    [SerializeField] private CanvasGroup canvasGroup;

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
            StartCoroutine(LerpRoutine(time));
        }
    }

    private IEnumerator LerpRoutine(float time)
    {
        canAnimate = false;

        while (!lerp.Evaluate(Time.deltaTime, time))
        {
            canvasGroup.alpha = lerp.Value;
            yield return null;
        }

        canvasGroup.alpha = lerp.Value;
        canAnimate = true;
    }
}
