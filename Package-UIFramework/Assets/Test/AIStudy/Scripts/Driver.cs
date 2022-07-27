using UnityEngine;

public class Driver : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Transform target = null;

    private void Update()
    {
        Move(GetInput());
        Face(target);
    }

    private Vector3 GetInput()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        return new Vector3(xAxis, 0, yAxis);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(movementSpeed * Time.deltaTime * direction, Space.World);
    }

    private void Face(Transform target)
    {
        transform.Rotate(0, GetAngleTo(target.position), 0);
    }

    private float GetAngleTo(Vector3 target)
    {
        Vector3 start = transform.forward;
        Vector3 end = target - transform.position;
        float dot = Vector3.Dot(start, end);
        float angle = Mathf.Acos(dot / (start.magnitude * end.magnitude));
        angle = Vector3.Angle(start, end); // Same operation as line above

        Debug.DrawRay(transform.position, start * 10, Color.green);
        Debug.DrawRay(transform.position, end, Color.red);

        angle = Vector3.SignedAngle(start, end, Vector3.up);
        return angle;
    }

    // Vector3.SignedAngle() already performs a Cross Product operation
    private int GetDirectionTo(Vector3 target)
    {
        Vector3 cross = Vector3.Cross(transform.forward, target);
        return cross.y > 0 ? 1 : -1;
    }
}
