using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorGroup : MonoBehaviour
{
    public Transform parent = null;
    public bool playOnStart = false;
    public bool loop = false;

    private void Start()
    {
        if(playOnStart)
        {
            Animate();
        }
    }

    public void Animate()
    {
        if (!parent)
        {
            parent = transform;
        }

        List<LerpAnimatorBase> animators = new List<LerpAnimatorBase>();
        animators.AddRange(GetComponents<LerpAnimatorBase>());

        foreach (Transform transform in parent)
        {
            animators.AddRange(transform.GetComponents<LerpAnimatorBase>());
        }

        foreach (LerpAnimatorBase animator in animators)
        {
            animator.Animate(true);
        }
    }
}
