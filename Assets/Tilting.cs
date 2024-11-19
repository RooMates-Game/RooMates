using UnityEngine;

public class Tilt : MonoBehaviour
{
    // Oscillation parameters
    [SerializeField] private float tiltAmount = 15f;  // Maximum tilt angle in degrees
    [SerializeField] private float frequency = 1f;    // Oscillation frequency (cycles per second)
    [SerializeField] private float centerPosition = 0f; // Starting position along the axis (X or Y)

    private float time;

    void Start()
    {
        // Set the initial position to the center position before starting the oscillation
        transform.position = new Vector3(centerPosition, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // Calculate the oscillation (left and right) based on the sine wave
        time += Time.deltaTime;  // Increase time for smooth oscillation
        float oscillation = Mathf.Sin(time * 2 * Mathf.PI * frequency) * tiltAmount;

        // Apply the oscillation to the position (along the X-axis for horizontal movement)
        transform.position = new Vector3(centerPosition + oscillation, transform.position.y, transform.position.z);
    }
}
