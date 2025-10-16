using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : State
{
    public StateTransition(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) { }

    private bool isVelocityZero = false;
    public override void Enter()
    {
        player.move.SetGravityScaleToOriginal();
    }
    public override void Update()
    {
        //가만히 있을 때 모션 컨트롤 등

        if (player.input.IsClicked) stateMachine.ChangeState(player.stateJump);
        if (isVelocityZero)
        {
            isVelocityZero = false;
            player.anim.PlayAnim(AnimID.transition);
        }
    }
    public override void FixedUpdate()
    {
        float velY = player.move.GetVelocityY();
        if (-0.1f < velY && velY < 0.1f)
        {
            isVelocityZero = true;
        }
    }
    public override void Exit() { }


}
