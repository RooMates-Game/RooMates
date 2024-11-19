using UnityEngine;

public class Resize : MonoBehaviour
{   
    
    [SerializeField]public float maxScale = 0/7f;  // Maximum scale
    [SerializeField]public float minScale = 0.2f; // Minimum scale
    [SerializeField]public float speed = 2f;     // Speed of scaling

    private bool isGrowing = true;  // Flag to check if the object is growing or shrinking

    // Update is called once per frame
    void Update()
    {
        // Calculate the scale factor using Lerp for smooth gradual scaling
        float targetScale = isGrowing ? maxScale : minScale;

        // Smoothly scale between the current scale and target scale
        float scale = Mathf.Lerp(transform.localScale.x, targetScale, Time.deltaTime * speed);

        // Apply the new scale to both X and Y axes
        transform.localScale = new Vector3(scale, scale, 1f);

        // Switch between growing and shrinking when the target scale is reached
        if (Mathf.Abs(transform.localScale.x - targetScale) < 0.01f)
        {
            isGrowing = !isGrowing;
        }
    }
}
