using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    private float force = .1f;
    private int maxForce = 12;
    public override void EnterState(PlayerStateManager player)
    {
        player._Animator.Play("Jumping");
        Debug.Log("+enter Jump state");
    }


    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("-exit Jump state");
        player.MoveVector.y = 0;
    }


    public override void UpdateState(PlayerStateManager player)
    {
        player.MoveVector.y += force;

        if(player.MoveVector.y >= maxForce)
        {
            player.SwitchState(player.FallingState);
        }

        player.Move();

    }


}
