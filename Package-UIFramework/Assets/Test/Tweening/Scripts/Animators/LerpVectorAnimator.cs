using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpVectorAnimator : LerpAnimatorBase
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
