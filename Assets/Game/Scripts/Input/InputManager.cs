using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    [HideInInspector] public Action<Vector2> OnMoveInput;
    [HideInInspector] public Action<bool> OnSprintInput;
    [HideInInspector] public Action OnJumpInput;
    [HideInInspector] public Action OnClimbInput;
    [HideInInspector] public Action OnCancelClimb;
    [HideInInspector] public Action OnChangePOV;
    [HideInInspector] public Action OnCrouchInput;
    [HideInInspector] public Action OnGlideInput;
    [HideInInspector] public Action OnCancelGlide;
    [HideInInspector] public Action OnPunchInput;
    [HideInInspector] public Action OnMainMenuInput;
    void Update()
    {
        CheckMovementInput();
        CheckCancelInput();
        CheckChangePOVInput();
        CheckClimbInput();
        CheckCrouchInput();
        CheckGlideInput();
        CheckJumpInput();
        CheckMainMenuInput();
        CheckPunchInput();
        CheckSprintInput();
    }
    
    private void CheckMovementInput(){
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Debug.Log("Vertical Axis: " + verticalAxis);
        Debug.Log("horizontal Axis: " + horizontalAxis);
        Vector2 InputAxis = new Vector2(horizontalAxis,verticalAxis);
        if(OnMoveInput != null){
            OnMoveInput(InputAxis);
        }
    }

    private void CheckSprintInput(){
        bool isHoldingSprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if(isHoldingSprintInput){
            if(OnSprintInput != null){
                OnSprintInput(true);
            }
        } else {
            if(OnSprintInput != null){
                OnSprintInput(false);
            }
        }
    }

    private void CheckJumpInput(){
        bool isJumpingInput = Input.GetKey(KeyCode.Space);

        if(isJumpingInput){
            if(OnJumpInput != null){
                OnJumpInput();
            }
        }
    }

    private void CheckCrouchInput(){
        bool isCrouchingInput = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        if(isCrouchingInput){
            OnCrouchInput();
        } 
    }

    private void CheckChangePOVInput(){
        bool isPOVChangeInput = Input.GetKey(KeyCode.Q);

        if(isPOVChangeInput){
            if(OnChangePOV != null){
                OnChangePOV();
            }
        } 
    }

    private void CheckClimbInput(){
        bool isClimbInput = Input.GetKey(KeyCode.E);

        if(isClimbInput){
            if(OnClimbInput != null){
                OnClimbInput();
            }
        } 
    }

    private void CheckGlideInput(){
        bool isGlideInput = Input.GetKey(KeyCode.G);

        if(isGlideInput){
            if(OnGlideInput != null){
                OnGlideInput();
            }
        } 
    }

    private void CheckCancelInput(){
        bool isCancelInput = Input.GetKey(KeyCode.C);

        if(isCancelInput){
            if(OnCancelClimb != null){
                OnCancelClimb();
            }
            if(OnCancelGlide != null){
                OnCancelGlide();
            }
        } 
    }

    private void CheckPunchInput(){
        bool isPunchInput = Input.GetKey(KeyCode.Mouse0);

        if(isPunchInput){
            OnPunchInput();
        } 
    }

    private void CheckMainMenuInput(){
        bool isMainMenuInput = Input.GetKey(KeyCode.Escape);

        if(isMainMenuInput){
            OnMainMenuInput();
        } 
    }
}
