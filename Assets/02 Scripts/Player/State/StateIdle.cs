using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : State
{
    public StateIdle(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) { }

    private float startGravityScaleRate = 2.0f;
    public override void Enter()
    {
        Debug.Log("Enter IdleState");
        player.anim.CrossFadeAnim(AnimID.idle, 0.1f);
        player.move.SetBodyTypeToKenematic();
    }
    public override void Update()
    {
        if (player.input.IsClicked)
        {
            stateMachine.ChangeState(player.stateJump);
        }
    }
    public override void Exit()
    {
        Debug.Log("Exit IdleState");
        player.move.SetBodyTypeToDynamic();
        player.move.SetGravityScale(player.move.GravityScaleOriginal * startGravityScaleRate);
    }
}
