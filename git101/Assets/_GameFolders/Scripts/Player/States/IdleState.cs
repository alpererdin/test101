using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player._Animator.Play("idle");
        Debug.Log("+enter idle state");
    }


    public override void ExitState(PlayerStateManager player)
    {
        
        Debug.Log("-exit idle state");
    }


    public override void UpdateState(PlayerStateManager player)
    {
        if(player.MoveVector.magnitude !=0)
        {
            player.SwitchState(player.WalkingState);
        }
        
    }


}
