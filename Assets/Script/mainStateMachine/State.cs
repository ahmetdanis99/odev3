public enum StateID
{
    Idle,
    Chase,
    Death,
    Attack
}
public interface State
{
    StateID GetID();
    void Enter(Agent agent);
    void Update(Agent agent);
    void Exit(Agent agent);
}
