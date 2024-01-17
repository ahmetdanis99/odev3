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
    void Enter(MainController controller);
    void Update(MainController controller);
    void Exit(MainController controller);
}
