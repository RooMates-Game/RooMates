using UnityEngine;

public class TiltingOscillator : MonoBehaviour
{
    public GameObject upperPart;           // Reference to the upper part of the object
    public GameObject lowerPart;           // Reference to the lower part of the object

    public float oscillationSpeed = 2f;    // Speed of oscillation
    public float tiltAngle = 30f;          // Maximum tilt angle (in degrees)
    public float damping = 0.98f;          // Damping factor to reduce the oscillation over time

    private float currentAngle = 0f;       // Current angle of the lower part
    private float angularVelocity = 0f;    // Current angular velocity

    private void Update()
    {
        // Simulate simple harmonic motion for the lower part
        float angleTarget = Mathf.Sin(Time.time * oscillationSpeed) * tiltAngle;

        // Apply damping to the angular velocity
        angularVelocity *= damping;

        // Calculate the angular force to move the object towards the target angle
        float angularAcceleration = (angleTarget - currentAngle) * oscillationSpeed;

        // Update the angular velocity and current angle
        angularVelocity += angularAcceleration * Time.deltaTime;
        currentAngle += angularVelocity * Time.deltaTime;

        // Apply the tilt only to the lower part (rotation around Z-axis)
        lowerPart.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

        // Ensure the upper part stays fixed (no rotation)
        upperPart.transform.rotation = Quaternion.identity;
    }
}
