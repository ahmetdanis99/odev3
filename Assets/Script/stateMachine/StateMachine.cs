using UnityEngine;

public class StateMachine
{
    public State[] states;
    public MainController controller;
    public StateID currentState;


    public StateMachine(MainController controller)
    {
        this.controller = controller;
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
        GetState(currentState)?.Update(controller);
    }
    public void ChangeState(StateID newState)
    {
        GetState(currentState)?.Exit(controller);
        currentState = newState;
        GetState(currentState)?.Enter(controller);
    }
}