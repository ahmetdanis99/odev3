public class DeathState : State
{
    public StateID GetID()
    {
        return StateID.Death;
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
