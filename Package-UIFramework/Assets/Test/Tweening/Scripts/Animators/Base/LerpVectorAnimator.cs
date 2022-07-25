using System.Collections;

public abstract class LerpVectorAnimator : LerpAnimatorBase
{
    protected LerpVector lerp;

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
}
