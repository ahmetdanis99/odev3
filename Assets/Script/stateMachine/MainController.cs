using UnityEngine;
using UnityEngine.AI;

public class MainController : MonoBehaviour
{
    public NavMeshAgent agent;
    public StateMachine stateMachine;
    public StateID initialState;
    public GameObject target = null;
    public int damage;
    public bool isLive;
    public Animator animate;
    public float movespeed;
    public bool attackOn = false;
    [HideInInspector] public EnemyController enemyController = null;
    [HideInInspector] public PlayerController playerController = null;
    public playerProps playerProps;
    public virtual void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        stateMachine = new StateMachine(this);
        isLive = true;
        playerProps = GetComponent<playerProps>();
        animate = GetComponent<Animator>();
        initialState = StateID.Idle;
        stateMachine.ChangeState(initialState);

    }

    public virtual void Update()
    {
        stateMachine.Update();
        setDead(playerProps);
    }
    public bool setDead(playerProps props)
    {
        if (props.PlayerHP <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void deathTrigger(GameObject obje)
    {
        Destroy(obje);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (attackOn)
        {
            other.GetComponent<playerProps>().PlayerHP -= damage;
            attackOn = false;
        }
    }
}