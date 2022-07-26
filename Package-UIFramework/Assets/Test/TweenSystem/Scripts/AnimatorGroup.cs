using System.Collections.Generic;
using Tween.Animators.Base;
using Tween.Extensions;
using UnityEngine;

namespace Tween.Animators
{
    public class AnimatorGroup : MonoBehaviour
    {
        [SerializeField] private Transform parent = null;
        [SerializeField] private bool playOnStart = false;
        [SerializeField] private bool loop = false;

        private void Start()
        {
            if (playOnStart)
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

            parent.ForEach(child =>
            animators.AddRange(child.GetComponents<LerpAnimatorBase>()));

            animators.ForEach(animator => animator.Animate(loop));
        }
    }
}