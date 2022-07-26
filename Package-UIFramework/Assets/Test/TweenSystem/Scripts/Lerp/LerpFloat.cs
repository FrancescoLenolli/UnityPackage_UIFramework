using Lerp.Base;
using UnityEngine;

namespace Lerp
{
    /// <summary>
    /// Lerp between two floating point values.
    /// The overwhelming majority of lerp operations
    /// can be by using this Class.
    /// </summary>
    public class LerpFloat : LerpBase
    {
        private float start;
        private float end;
        private float value;

        public float Value { get => value; }

        /// <summary>
        /// Get Base Lerp with start = 0, end = 1.
        /// </summary>
        public static LerpFloat Basic { get => new LerpFloat(0, 1); }

        public LerpFloat(float start, float end)
        {
            this.start = start;
            this.end = end;
        }

        public override bool Evaluate(float timeStep, float totalTime)
        {
            float newValue = value;
            float step = time / totalTime;

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
}