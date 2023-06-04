using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    private void OnMovement(InputValue value)
    {
        InputVector = value.Get<Vector2>();
        MoveVector.x = InputVector.x;
        MoveVector.z = InputVector.y;

    }
    private void OnJump(InputValue value)
    {
        if(CurrentState !=JumpingState && CurrentState !=FallingState)
        SwitchState(JumpingState);

    }
    private void OnSpeed(InputValue value)
    {
        if (CurrentState != JumpingState && CurrentState != FallingState)
            if (CurrentState == WalkingState)
            SwitchState(RunningState);


    }
}

