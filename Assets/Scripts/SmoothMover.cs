using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothMover : MonoBehaviour
{
    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);


    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveUp = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveDown = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction jump = new InputAction(type: InputActionType.Button);

    [SerializeField]
    [Tooltip("How many meters per second to move when action is pressed.")]
    private float speed = 1;

    private void Awake()
    {
        // Auto-bind actions if no bindings are set
        if (moveRight.bindings.Count == 0)
        {
            moveRight.AddBinding("<Keyboard>/rightArrow"); // Right Arrow for moving right
        }

        if (moveLeft.bindings.Count == 0)
        {
            moveLeft.AddBinding("<Keyboard>/leftArrow"); // Left Arrow for moving left
        }

        if (moveUp.bindings.Count == 0)
        {
            moveUp.AddBinding("<Keyboard>/upArrow"); // Up Arrow for moving up
        }

        if (moveDown.bindings.Count == 0)
        {
            moveDown.AddBinding("<Keyboard>/downArrow"); // Down Arrow for moving down
        }
    }


    private void OnEnable()
    {
        moveRight.Enable();
        moveLeft.Enable();
        moveUp.Enable();
        moveDown.Enable();

    }
    private void OnDisable()
    {
        moveRight.Disable();
        moveLeft.Disable();
        moveUp.Disable();
        moveUp.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight.IsPressed())
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (moveLeft.IsPressed())
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (moveUp.IsPressed())
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (moveDown.IsPressed())
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

    }
}