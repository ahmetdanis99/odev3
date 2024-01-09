public class AttackState : State
{
    public StateID GetID()
    {
        return StateID.Attack;
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
