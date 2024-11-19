using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeed = 100f; // Angular velocity

    void Update()
    {
        // rotate through y - axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
