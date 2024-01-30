using UnityEngine;

public class PlayerController : MainController
{
    public RaycastHit hit;
    public Camera cam;

    public override void Start()
    {
        base.Start();
        playerController = GetComponent<PlayerController>();
        stateMachine.RegisterState(new PlayerIdleState());
        stateMachine.RegisterState(new PlayerChaseState());
        stateMachine.RegisterState(new PlayerDeathState());
        stateMachine.RegisterState(new PlayerAttackState());
        movespeed = 7f;
    }
    public override void Update()
    {
        isLive = setDead(playerProps);
        if (isLive)
        {
            base.Update();
            hit = hitRaycast();
        }
        else{
            stateMachine.ChangeState(StateID.Death);
        }
    }
    public bool KeyMove()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public RaycastHit hitRaycast()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, Mathf.Infinity);
        }
        setTarget(hit);
        return hit;
    }
    public void resetRayacast()
    {
        hit = new RaycastHit();
    }

    public void setTarget(RaycastHit hit)
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                target = hit.collider.gameObject;
            }
            else
            {
                target = null;
            }
        }
    }
    public bool useEnv(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            return true;
        }
        return false;
    }
}
