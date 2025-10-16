using System.Collections;
using UnityEngine;

public class StateJump : State
{
    public StateJump(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) { }

    private bool isFirstFrame = false;

    public override void Enter()
    {
        base.Enter();
        isFirstFrame = true;
        Debug.Log("Enter JumpState");
        player.anim.PlayAnim(AnimID.jump);
        player.StartCoroutine(WaitAndChangeState(0.05f));
    }

    public override void FixedUpdate()
    {
        float velY = player.move.GetVelocityY();

        if (isFirstFrame)
        {
            isFirstFrame = false;
            if (velY < -player.lowRangeVelocityY)
            {
                player.move.AddImpulseUP(player.jumpForce);
            }
            if (-player.lowRangeVelocityY <= velY && velY < player.lowRangeVelocityY)
            {
                player.move.AddImpulseUP(player.jumpForce * player.jumpForceRateAtLowRise);
            }
            if (player.lowRangeVelocityY <= velY && velY < player.middleRangeVelocityY)
            {
                player.move.AddImpulseUP(player.jumpForce * player.jumpForceRateAtMiddleRise);
            }
            if (player.middleRangeVelocityY <= velY)
            {
                player.move.AddImpulseUP(player.jumpForce * player.jumpForceRateAtHighRise);
            }
        }
    }
    public override void Exit()
    {
        Debug.Log("Exit JumpState");
    }

    IEnumerator WaitAndChangeState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        stateMachine.ChangeState(player.stateTransition);
    }
}
