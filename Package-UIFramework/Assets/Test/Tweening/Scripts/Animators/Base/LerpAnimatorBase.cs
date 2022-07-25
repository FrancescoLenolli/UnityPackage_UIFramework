using UnityEngine;

/// <summary>
/// Base class for all Lerp Animator components.
/// </summary>
public abstract class LerpAnimatorBase : MonoBehaviour
{
    protected bool canAnimate = true;

    /// <summary>
    /// Initialise Animator values.
    /// </summary>
    public virtual void Init() { }

    /// <summary>
    /// Start animation.
    /// </summary>
    public virtual void Animate(bool loop = false) { }
}
