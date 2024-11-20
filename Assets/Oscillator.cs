using UnityEngine;

public class Oscillator : MonoBehaviour
{
    
    [Tooltip("The maximum angle of oscillation (in degrees)")]
    [SerializeField]public float maxAngle = 30f;

    [Tooltip("Speed of the oscillation (controls how fast the oscillation happens)")]
    [SerializeField]public float speed = 2f;

    private float startRotationZ;

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial Z rotation of the object (to calculate oscillation from there)
        startRotationZ = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the oscillation using a sine function to get a real world back and forth movement
        float angle = Mathf.Sin(Time.time * speed) * maxAngle;

        // Apply the oscillation as rotation around the Z-axis (tilting left and right in 2D)
        transform.rotation = Quaternion.Euler(0f, 0f, startRotationZ + angle);
    }
}
