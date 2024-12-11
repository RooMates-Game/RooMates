using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundCheck : MonoBehaviour
{
    public bool grounded = false;

    // Define an InputAction for jumping
    [SerializeField] private InputAction jumpAction;

    private Rigidbody2D rb;

    private void OnEnable()
    {
        // Enable the input action when the object is enabled
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the input action when the object is disabled
        jumpAction.Disable();
    }

    private void Start()
    {
        // Cache the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing!");
        }
    }

    private void Update()
    {
        // Check if the jump action is triggered and the player is grounded
        if (jumpAction.triggered && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }
}
