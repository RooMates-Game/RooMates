using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float followSpeed = 2f; // Speed at which the camera follows the target
    [SerializeField] public GameObject target; // The target for the camera to follow

    void Update()
    {
        // Check if the target is assigned
        if (target == null)
        {
            Debug.LogError("Target is not assigned to the CameraFollow script!");
            return;
        }

        // Get the target's position
        Vector3 posTarget = target.transform.position;

        // Create a new position for the camera, keeping the z-axis at -10 (for 2D)
        Vector3 newPos = new Vector3(posTarget.x, posTarget.y, -10f);

        // Smoothly interpolate the camera's position toward the target
        Vector3 smoothedPos = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

        // Update the camera's position
        transform.position = smoothedPos;
    }
}
