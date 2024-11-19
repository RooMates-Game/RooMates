using UnityEngine;
using UnityEngine.InputSystem;  // Make sure to include this namespace to use InputAction

public class ToggleVisibility : MonoBehaviour
{
    private SpriteRenderer[] childRenderers; // Array to hold all SpriteRenderer components in the hierarchy
    public InputAction toggleVisibilityAction; // The action that listens to the button press

    private void Awake()
    {
        // Find all SpriteRenderer components in the object and its children
        childRenderers = GetComponentsInChildren<SpriteRenderer>();

        // If no SpriteRenderer components are found, log an error
        if (childRenderers.Length == 0)
        {
            Debug.LogError("No SpriteRenderer components found on this object or its children.");
        }

        // If the action is not set via the Inspector, define it here
        if (toggleVisibilityAction == null)
        {
            toggleVisibilityAction = new InputAction("ToggleVisibility");
        }

        // Check if there is no binding, and set the default binding to the 'E' key
        if (toggleVisibilityAction.bindings.Count == 0)
        {
            toggleVisibilityAction.AddBinding("<Keyboard>/e"); // Default to 'E' key if no binding is set
        }

        // Attach the ToggleObjectVisibility method to be called when the action is performed
        toggleVisibilityAction.performed += ctx => ToggleObjectVisibility();
    }

    private void OnEnable()
    {
        // Start listening for the action
        toggleVisibilityAction.Enable();
    }

    private void OnDisable()
    {
        // Stop listening for the action
        toggleVisibilityAction.Disable();
    }

    // Method to toggle the visibility of all child SpriteRenderers
    private void ToggleObjectVisibility()
    {
        // Iterate through all the child SpriteRenderers and toggle their enabled state
        foreach (var renderer in childRenderers)
        {
            if (renderer != null)
            {
                renderer.enabled = !renderer.enabled; // Toggle visibility
            }
        }
    }
}
