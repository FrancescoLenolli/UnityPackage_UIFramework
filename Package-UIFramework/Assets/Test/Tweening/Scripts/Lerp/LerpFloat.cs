using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFloat : LerpBase
{
    private float start;
    private float end;
    private float value;

    public float Value { get => value; }

    public LerpFloat(float start, float end)
    {
        this.start = start;
        this.end = end;
    }

    public override bool Evaluate(float timeStep, float totalTime, bool smooth = true)
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
