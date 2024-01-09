using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public NavMeshAgent agent;
    public StateMachine stateMachine;
    public StateID initialState;
    public virtual void Start()
    {
        Debug.Log("32");
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new StateMachine(this);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
