
using System.Collections;
using UnityEngine;

public class StateDeath : State
{
    public StateDeath(PlayerController player, StateMachine stateMachine) : base(player, stateMachine) { }

    

    private float waitTimeBeforeFall = 1.0f;
    private Coroutine waitTimeAndReturn;
    public override void Enter()
    {
        player.data.IsDeath = true;
        player.IsRotate = false;
        player.move.SetVelocityY(0.0f);
        player.move.SetVelocityX(0.0f);
        player.move.DontRotate();
        player.anim.CrossFadeAnim(AnimID.death, 0.5f);
        player.move.SetBodyTypeToKenematic();
        waitTimeAndReturn = player.StartCoroutine(WaitTimeAndReturnBodyType(waitTimeBeforeFall));

        if (player.pipePool != null)
        {
            
            player.pipePool.PauseAllPipes();
        }
    }
    public override void Update() { }
    public override void FixedUpdate() { }
    public override void Exit()
    {
        if (waitTimeAndReturn != null)
        {
            player.StopCoroutine(waitTimeAndReturn);
        }
        player.IsRotate = true;
    }

    IEnumerator WaitTimeAndReturnBodyType(float time)
    {
        yield return new WaitForSeconds(time);
        player.IsRotate = true;
        player.move.SetBodyTypeToDynamic();
        player.move.DoRotate();
    }
}
