using UnityEngine;

public class AnimatorRotation : LerpFloatAnimator
{
    [SerializeField] private float startValue = 0f;
    [SerializeField] private float endValue = 360f;
    [SerializeField] private Axis rotationAxis = Axis.X;
    [SerializeField] private float time = 1f;
    [SerializeField] private Transform target = null;

    public override void Init()
    {
        if (lerp == null)
        {
            lerp = new LerpFloat(startValue, endValue, false);
            if (!target)
            {
                target = transform;
            }
        }
    }

    public override void Animate(bool loop = false)
    {
        StartAnimation(loop, time, SetRotation, false);
    }

    private void SetRotation(float value)
    {
        target.SetSingleAngle(rotationAxis, value);
    }
}
