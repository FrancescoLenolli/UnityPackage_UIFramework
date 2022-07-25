using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpVector : LerpBase
{
    private Vector3 start;
    private Vector3 end;
    private Vector3 value;

    public Vector3 Value { get => value; }

    public LerpVector(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;
    }

    public override bool Evaluate(float timeStep, float totalTime, bool smoothStep = true)
    {
        Vector3 newValue = value;
        float step = smoothStep ?
            Mathf.SmoothStep(0.0f, 1.0f, time / totalTime) :
            time / totalTime;

        if (time <= totalTime)
        {
            newValue = Vector3.Lerp(start, end, step);
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
        time = 0f;
    }

    public override void Reverse()
    {
        Vector3 value = start;
        start = end;
        end = value;
    }
}
