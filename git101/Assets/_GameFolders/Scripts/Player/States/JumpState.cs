using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    private float force = .01f;
    private int maxForce = 5;
    public override void EnterState(PlayerStateManager player)
    {
        

        player._Animator.Play("Jumping");
        Debug.Log("+enter Jump state");
        player.Gravity = new Vector3(0, -4, 0);
    }


    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("-exit Jump state");
        player.MoveVector.y = 0;
    }
    ///animator

    public override void UpdateState(PlayerStateManager player)
    {
        player.MoveVector.y += force;

        if(player.MoveVector.y >= maxForce)
        {
            player.Gravity = new Vector3(0, -9.81f, 0);
            player.SwitchState(player.FallingState);
        }

        player.Move();

    }


}
