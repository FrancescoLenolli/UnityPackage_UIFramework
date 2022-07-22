using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorGroup : MonoBehaviour
{
    public Transform canvas = null;

    public void Animate()
    {
        foreach (Transform transform in canvas)
        {
            AnimatorBase[] animators = transform.GetComponents<AnimatorBase>();
            foreach(AnimatorBase animator in animators)
            {
                animator.Animate();
            }
        }

    }
}
