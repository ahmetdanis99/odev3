using UnityEngine;
using UnityEngine.AI;

public class playerControler : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent;
    private RaycastHit hit;
    public int maxPlayerHP;
    public int playerPower;
    public float moveSpeed = 5f;
    public float moveX;
    public float moveZ;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        statsCheck();
    }
    private int playerHP_p;
    public int playerHP
    {
        get
        {
            return playerHP_p;
        }
        set
        {
            if (value < 0)
            {
                playerHP_p = 0;
            }
            else if (value > maxPlayerHP)
            {
                playerHP_p = maxPlayerHP;
            }
            else
            {
                playerHP_p = value;
            }
            if (playerHP_p <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        Debug.Log("Öldün");
    }
    public void TakeDamage(int damage)
    {
        playerHP -= damage;
    }
    public void statsCheck()
    {
        maxPlayerHP = gamemanager.instance.defaultStats["health"];
        playerPower = gamemanager.instance.defaultStats["power"];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Raycast Hit");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agentSelector(hit);
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
            agent.ResetPath();
            Move(moveX, moveZ);
            Debug.Log("keybroad move");
        }
    }

    //~~ Klavye ile hareket methodları
    public void agentSelector(RaycastHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Ground"))
        {
            Move(hit);
        }
        else if (hit.collider.gameObject.CompareTag("Enemy"))
        {
            Attack(hit);
        }
    }
    public void Move(float moveX, float moveZ)
    {
        Debug.Log("keybroad move!!!!" + moveX + moveZ);
        Vector3 hareket = new Vector3(moveX, 0f, moveZ);
        hareket = cam.transform.TransformDirection(hareket);
        hareket.y = 0f;

        hareket.Normalize();
        hareket *= 5f * Time.deltaTime;

        transform.Translate(hareket);
    }
    public void Move(RaycastHit hit)
    {
        Debug.Log("agent move");
        agent.SetDestination(hit.point);
    }
    public void Attack(RaycastHit hit)
    {
        if (!(Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 5))
        {
            agent.SetDestination(hit.collider.gameObject.transform.position);
            Debug.Log("GoAttack");
        }
        else if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) < 5)
        {
            agent.ResetPath();
            Debug.Log("Attack");
        }
    }
}