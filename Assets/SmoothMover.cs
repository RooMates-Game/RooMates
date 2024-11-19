using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothMover : MonoBehaviour
{
    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);


    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);


    [SerializeField]
    [Tooltip("How many meters per second to move when action is pressed.")]
    private float speed =1;


    private void OnEnable() {
        moveRight.Enable();
        moveLeft.Enable();
        
    }
    private void OnDisable() {
        moveRight.Disable();
        moveLeft.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight.IsPressed()){
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }

        if(moveLeft.IsPressed()){
            transform.position += new Vector3(-speed * Time.deltaTime,0,0);
        }
        
    }
}
