using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    private Camera cam; // Reference to the Camera component
    private float initialOrthographicSize; // The starting size of the orthographic camera
    private float initialAspectRatio; // The initial aspect ratio of the screen (width/height)

    void Start()
    {
        // Get the Camera component
        cam = GetComponent<Camera>();

        // Save the initial orthographic size
        initialOrthographicSize = cam.orthographicSize;

        // Calculate and save the initial aspect ratio
        initialAspectRatio = (float)Screen.width / Screen.height;
    }

    void Update()
    {
        // Calculate the current aspect ratio
        float currentAspectRatio = (float)Screen.width / Screen.height;

        // Adjust the orthographic size to compensate for the aspect ratio change
        cam.orthographicSize = initialOrthographicSize * (initialAspectRatio / currentAspectRatio);
    }
}