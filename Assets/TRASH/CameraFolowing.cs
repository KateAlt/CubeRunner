using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    // public Transform target;

    // public float smoothSpeed = 0.15f;
    // public Vector3 offset;

    // void FixedUpdate()
    // {
    //     Vector3 desiredPosition = target.position + offset;
    //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //     transform.position = smoothedPosition;

    //     // transform.LookAt(target);

    //     // Vector3 lookDirection = target.position - transform.position;
    //     // lookDirection.Normalize();

    //     // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), smoothSpeed * Time.deltaTime);
    // }

    public Transform target;            // Target to follow
    public float smoothSpeed = 0.125f;   // Smoothing factor for position
    public float smoothRotation = 5f;   // Smoothing factor for rotation
    public Vector3 offset = new Vector3(0, 2, -5);  // Offset from the target
    public Vector3 offsetRotation = new Vector3(0, 0, 0);  // Offset rotation angles
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;

            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position) * Quaternion.Euler(offsetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothRotation * Time.deltaTime);
        }
    }
}
