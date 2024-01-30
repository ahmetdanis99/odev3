using UnityEngine;
public class PlayerChaseState : State
{
    public StateID GetID()
    {
        return StateID.Chase;
    }
    public void Enter(MainController controller)
    {
        controller.playerController.animate.SetBool("chase", true);
    }

    public void Exit(MainController controller)
    {
        controller.playerController.animate.SetBool("chase", false);
    }
    public void Update(MainController controller)
    {

        if (controller.playerController.KeyMove() == true)
        {
            Move(controller.playerController);
        }
        if (controller.playerController.hit.collider != null)
        {
            if (controller.target != null)
            {
                Move(controller.playerController, controller.target);
            }
            else
            {
                Move(controller.playerController, controller.playerController.hit);
            }
        }
        if (controller.target != null)
        {
            float distance = Vector3.Distance(controller.playerController.transform.position, controller.target.transform.position);
            if (distance <= 4)
            {
                controller.stateMachine.ChangeState(StateID.Attack);
            }
        }
        else
        {
            if (controller.agent.hasPath != true && controller.playerController.KeyMove() == false)
            {
                if (controller.agent.remainingDistance <= 0)
                {
                    controller.stateMachine.ChangeState(StateID.Idle);

                }
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
        movement *= controller.playerController.movespeed * Time.deltaTime;

        mRotation(controller.playerController);

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
    public void Move(MainController controller, GameObject target)
    {
        controller.playerController.agent.SetDestination(target.transform.position);
    }
}