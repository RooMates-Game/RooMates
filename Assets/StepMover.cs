using UnityEngine;
using UnityEngine.InputSystem;

public class StepMover : MonoBehaviour
{
    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);


    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);


    [SerializeField]
    [Tooltip("How many meters to move right when action is pressed.")]
    private float stepSize =1;


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
        if(moveRight.WasPressedThisFrame()){
            transform.position += new Vector3(stepSize,0,0);
        }

        if(moveLeft.WasPressedThisFrame()){
            transform.position += new Vector3(-stepSize,0,0);
        }
        
    }
}
