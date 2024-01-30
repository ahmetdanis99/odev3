using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    private float distance;
    public StateID GetID()
    {
        return StateID.Idle;
    }
    public void Enter(MainController controller)
    {
        controller.enemyController.animate.SetBool("idle", true);
    }

    public void Exit(MainController controller)
    {
        controller.enemyController.animate.SetBool("idle", false);
    }
    public void Update(MainController controller)
    {
        if (distance <= 5)
        {
            controller.stateMachine.ChangeState(StateID.Chase);
        }
    }
}
