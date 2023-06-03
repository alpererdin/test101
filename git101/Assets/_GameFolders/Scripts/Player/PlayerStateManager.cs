using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public partial class PlayerStateManager : MonoBehaviour
{
   public  bool isSprinting;


    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        //PlayerSpeed = 5f;
        PlayerRotateSpeed = 180;
        
        _gravityVector = new Vector3(0, -9.81f, 0);

        Input.actions["Speed"].started += OnSprintPerformed;
        Input.actions["Speed"].canceled += OnSprintCanceled;

    }
    void Start()
    {
        CurrentState = IdlingState;
        CurrentState.EnterState(this);
        
    }

     void Update()
    {
        if(CurrentState!=JumpingState && 
            CurrentState != FallingState && 
            !Controller.isGrounded)
        {
            SwitchState(FallingState);
        }
        CurrentState.UpdateState(this);
         

        ApplyGravity();
        
    }
    public void SwitchState(PlayerBaseState state)
    {
        CurrentState.ExitState(this);
        CurrentState = state;
        state.EnterState(this);
    }
    #region Movement
    public void ApplyGravity()
    {
        Controller.Move(_gravityVector * Time.deltaTime);
    }
    public void Move(float Speed=5f)
    {
        
        Controller.Move(Speed * MoveVector * Time.deltaTime);
        RotateTowardsVector();
    }
    public void RotateTowardsVector()
    {
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
        if (xzDirection.magnitude == 0) return;

        var rotation = Quaternion.LookRotation(xzDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed);
    }
    #endregion

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        isSprinting = true;
        if (Controller.isGrounded && CurrentState == WalkingState)
        {
            
            SwitchState(RunningState);
        }
       /* if(CurrentState!=WalkingState)
        {
            SwitchState(IdlingState);
        }
        */
       
        
    }

    private void OnSprintCanceled(InputAction.CallbackContext context)
    {
        isSprinting = false;
        SwitchState(IdlingState);
    }
}
