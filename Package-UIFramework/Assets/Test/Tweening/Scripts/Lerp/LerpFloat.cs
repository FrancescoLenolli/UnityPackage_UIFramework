using UnityEngine;

public class LerpFloat : LerpBase
{
    private float start;
    private float end;
    private float value;

    public float Value { get => value; }

    public LerpFloat(float start, float end, bool smooth = true)
    {
        this.start = start;
        this.end = end;
        this.smooth = smooth;
    }

    public override bool Evaluate(float timeStep, float totalTime)
    {
        float newValue = value;
        float step = smooth ?
            Mathf.SmoothStep(0.0f, 1.0f, time / totalTime) :
            time / totalTime;

        if (time <= totalTime)
        {
            newValue = Mathf.Lerp(start, end, step);
            value = newValue;
            time += timeStep;
            return false;
        }

        value = newValue;
        isComplete = true;
        return true;
    }

    public override void Reset()
    {
        base.Reset();
        value = 0f;
        time = 0f;
    }

    public override void Reverse()
    {
        float value = start;
        start = end;
        end = value;
    }
}
