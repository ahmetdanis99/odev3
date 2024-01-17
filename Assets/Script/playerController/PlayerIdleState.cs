using UnityEngine;

public class PlayerIdleState : State
{
    public StateID GetID()
    {
        return StateID.Idle;
    }
    public void Enter(MainController controller)
    {

    }

    public void Exit(MainController controller)
    {

    }
    public void Update(MainController controller)
    {
        if (controller.playerController.KeyMove() == true || controller.playerController.hit.collider != null)
        {
            controller.stateMachine.ChangeState(StateID.Chase);
        }

    }
}
