using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { X, Y, Z }

public static class ExtensionMethods
{
    public static void SetSinglePosition(this Transform transform, Axis axis, float newValue)
    {
        Vector3 vector = transform.position;

        switch(axis)
        {
            case Axis.X:
                transform.position = new Vector3(newValue, vector.y, vector.z);
                break;
            case Axis.Y:
                transform.position = new Vector3(vector.x, newValue, vector.z);
                break;
            case Axis.Z:
                transform.position = new Vector3(vector.x, vector.y, newValue);
                break;
            default:
                break;
        }
    }

    public static void SetSingleAngle(this Transform transform, Axis axis, float newValue)
    {
        Quaternion rotation = transform.rotation;

        switch (axis)
        {
            case Axis.X:
                transform.rotation = Quaternion.Euler(newValue, rotation.y, rotation.z);
                break;
            case Axis.Y:
                transform.rotation = Quaternion.Euler(rotation.x, newValue, rotation.z);
                break;
            case Axis.Z:
                transform.rotation = Quaternion.Euler(rotation.x, rotation.y, newValue);
                break;
            default:
                break;
        }
    }

    public static void SetSingleScale(this Transform transform, Axis axis, float newValue)
    {

        Vector3 scale = transform.localScale;

        switch (axis)
        {
            case Axis.X:
                transform.localScale = new Vector3(newValue, scale.y, scale.z);
                break;
            case Axis.Y:
                transform.localScale = new Vector3(scale.x, newValue, scale.z);
                break;
            case Axis.Z:
                transform.localScale = new Vector3(scale.x, scale.y, newValue);
                break;
            default:
                break;
        }
    }
}
