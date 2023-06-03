using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player._Animator.SetBool("isRunning", true);

        player._Animator.Play("Running");
        Debug.Log("+enter Run state");
    }


    public override void ExitState(PlayerStateManager player)
    {
        player._Animator.SetBool("isRunning", false);

        Debug.Log("-exit Run state");
    }


    public override void UpdateState(PlayerStateManager player)
    {
        if (player.MoveVector.magnitude == 0)
        {
            player.SwitchState(player.IdlingState);
        }
        player.Move(10f);


    }
}


 