using UnityEngine;

public class StateMachine
{
    public State[] states;
    public Agent agent;
    public StateID currentState;

    public StateMachine(Agent agent)
    {
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(StateID)).Length;
        states = new State[numStates];
    }
    public void RegisterState(State state)
    {
        int index = (int)state.GetID();
        states[index] = state;
    }
    public State GetState(StateID stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void Update()
    {
        Debug.Log(currentState.ToString());
        GetState(currentState)?.Update(agent);
    }
    public void ChangeState(StateID newState)
    {
        GetState(currentState)?.Exit(agent);
        currentState = newState;
        GetState(currentState)?.Enter(agent);
    }
}