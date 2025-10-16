public interface IState
{
    void Enter();
    void Update();
    void FixedUpdate();
    void Exit();
}

public class State : IState
{
    protected PlayerController player;
    protected StateMachine stateMachine;
    public State(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;

    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}
