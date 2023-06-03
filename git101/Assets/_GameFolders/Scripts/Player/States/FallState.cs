using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player._Animator.Play("Falling");
        Debug.Log("+enter Fall state");
    }


    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("-exit Fall state");
    }


    public override void UpdateState(PlayerStateManager player)
    {
        if (player.Controller.isGrounded)
        {
            player.SwitchState(player.IdlingState);
        }else
        {
            player.Move();
        }

    }


}
