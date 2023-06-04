using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player._Animator.SetBool("isWalking",true);
       // player._Animator.Play("Walking");
        Debug.Log("+enter walk state");
       
    }


    public override void ExitState(PlayerStateManager player)
    {
        player._Animator.SetBool("isWalking", false);
        Debug.Log("-exit walk state");
        
    }


    public override void UpdateState(PlayerStateManager player)
    {
        if (player.MoveVector.magnitude == 0)
        {
            player.SwitchState(player.IdlingState);
        }
        else
        {
            player.Move();
        }
        if(player.isSprinting)
        {
           player.SwitchState(player.RunningState);
        }

    }


}
