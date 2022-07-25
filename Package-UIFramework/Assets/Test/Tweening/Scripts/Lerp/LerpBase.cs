/// <summary>
/// Base class for all Lerp types.
/// </summary>
public abstract class LerpBase
{
    protected float time;
    protected bool isComplete;
    /*
     * TRUE: Lerp value will ease in and out.
     * FALSE: Lerp value will be linear from start to finish.
     */
    protected bool smooth;

    /// <summary>
    /// Returns TRUE if the Lerp operation is complete (t = 1).
    /// </summary>
    public bool IsComplete { get => isComplete; }

    /// <summary>
    /// Calculate Lerp value.
    /// </summary>
    /// <param name="smoothStep">Check to get smooth ease-in/ease-out movement.</param>
    /// <returns>TRUE if the operation in complete (t = 1).</returns>
    public abstract bool Evaluate(float timeStep, float totalTime);

    /// <summary>
    /// Reverse Start and End values. Can be used to create loops.
    /// </summary>
    public abstract void Reverse();

    /// <summary>
    /// Reset Lerp values.
    /// </summary>
    public virtual void Reset() { isComplete = false; }
}
