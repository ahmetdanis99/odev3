using UnityEngine;
using UnityEngine.AI;

public class MainController : MonoBehaviour
{
    public NavMeshAgent agent;
    public StateMachine stateMachine;
    public StateID initialState;
    public GameObject target = null;
    [HideInInspector] public PlayerController playerController = null;
    [HideInInspector] public EnemyController enemyController = null;
    public virtual void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        stateMachine = new StateMachine(this);
    }

    public virtual void Update()
    {
        stateMachine.Update();
    }
}
