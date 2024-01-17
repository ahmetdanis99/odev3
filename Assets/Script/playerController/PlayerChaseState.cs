using UnityEngine;
public class PlayerChaseState : State
{
    public StateID GetID()
    {
        return StateID.Chase;
    }
    public void Enter(MainController controller)
    {

    }

    public void Exit(MainController controller)
    {

    }
    public void Update(MainController controller)
    {
        if (controller.playerController.KeyMove() == true)
        {
            Move(controller);
        }
        if (controller.playerController.hit.collider != null)
        {
            Move(controller, controller.playerController.hit);
        }
        else
        {
            if (controller.agent.hasPath != true && controller.playerController.KeyMove() == false)
            {
                controller.stateMachine.ChangeState(StateID.Idle);
            }
        }
    }
    public void Move(MainController controller)
    {
        if (controller.agent.hasPath != false)
        {
            controller.agent.ResetPath();
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement.Normalize();
        movement *= controller.playerController.movespeedaq * Time.deltaTime;

        mRotation(controller);

        controller.playerController.transform.Translate(movement);
    }
    public void mRotation(MainController controller)
    {
        Quaternion tRotation = Quaternion.LookRotation(controller.playerController.cam.transform.forward);
        controller.playerController.transform.rotation = Quaternion.Slerp(controller.playerController.transform.rotation, tRotation, 10 * Time.deltaTime);
    }
    public void Move(MainController controller, RaycastHit hit)
    {
        controller.playerController.agent.SetDestination(hit.point);
        controller.playerController.resetRayacast();
    }
}
