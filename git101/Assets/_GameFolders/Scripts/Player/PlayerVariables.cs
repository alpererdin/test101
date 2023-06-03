using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public partial class PlayerStateManager
{
    
    public CharacterController Controller;
    public PlayerInput Input;
    public PlayerBaseState CurrentState;
    public Animator _Animator;

    public Vector3 MoveVector;
    public Vector2 InputVector;
    public float PlayerSpeed,PlayerRotateSpeed;

    private Vector3 _gravityVector;

    #region ContreteStates
    public WalkState WalkingState = new WalkState();
    public IdleState IdlingState = new IdleState();
    public FallState FallingState = new FallState();

    public JumpState JumpingState = new JumpState();
    public RunState RunningState = new RunState();

    #endregion
}
