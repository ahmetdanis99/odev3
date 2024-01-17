using UnityEngine;

public class PlayerController : MainController
{
    public RaycastHit hit;
    public Camera cam;
    public float movespeedaq = 7f;
    public override void Start()
    {
        base.Start();
        playerController = GetComponent<PlayerController>();
        stateMachine.RegisterState(new PlayerIdleState());
        stateMachine.RegisterState(new PlayerChaseState());
        stateMachine.RegisterState(new PlayerDeathState());
        stateMachine.RegisterState(new PlayerAttackState());
        initialState = StateID.Idle;
        stateMachine.ChangeState(initialState);
    }
    public override void Update()
    {
        base.Update();
        hit = hitRaycast();
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
        return hit;
    }
    public void resetRayacast()
    {
        hit = new RaycastHit();
    }
}
