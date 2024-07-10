using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;  // The target to follow
    public Transform lockTarget;
    public float smoothSpeed = 0.125f;  // Speed of smooth damp
    public Vector3 offset;  // Offset from the target's position

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(lockTarget);  // Ensure the camera looks at the target
        }
    }
}
