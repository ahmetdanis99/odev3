public class IdleState : State
{
    public StateID GetID()
    {
        return StateID.Idle;
    }
    public virtual void Enter(Agent agent)
    {
    }

    public virtual void Exit(Agent agent)
    {
    }

    public virtual void Update(Agent agent)
    {
    }
}