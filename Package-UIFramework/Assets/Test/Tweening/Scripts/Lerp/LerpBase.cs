using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all Lerp types.
/// </summary>
public abstract class LerpBase
{
    protected float time;
    protected bool isComplete;

    /// <summary>
    /// Returns TRUE if the Lerp operation is complete (t = 1).
    /// </summary>
    public bool IsComplete { get => isComplete; }

    /// <summary>
    /// Calculate Lerp value.
    /// </summary>
    /// <param name="smoothStep">Check to get smooth ease-in/ease-out movement.</param>
    /// <returns>TRUE if the operation in complete (t = 1).</returns>
    public abstract bool Evaluate(float timeStep, float totalTime, bool smooth = true);

    /// <summary>
    /// Reverse Start and End values. Can be used to create loops.
    /// </summary>
    public abstract void Reverse();

    /// <summary>
    /// Reset Lerp values.
    /// </summary>
    public virtual void Reset() { isComplete = false; }
}
