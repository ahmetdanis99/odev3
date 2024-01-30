using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyChaseState : State
{
    public StateID GetID()
    {
        return StateID.Chase;
    }
    public void Enter(MainController controller)
    {
        controller.enemyController.animate.SetBool("chase", true);
    }

    public void Exit(MainController controller)
    {
        controller.enemyController.animate.SetBool("chase", false);
    }
    public void Update(MainController controller)
    {
        float distance = Vector3.Distance(
            controller.enemyController.transform.position,
            controller.target.transform.position);

        if (distance > 15)
        {
            controller.stateMachine.ChangeState(StateID.Idle);
        }
        else
        {
            if (distance <= 6)
            {
                controller.stateMachine.ChangeState(StateID.Attack);
            }
            else
            {
                Move(controller, controller.target);

            }
        }

    }
    public void Move(MainController controller, GameObject target)
    {
        controller.agent.SetDestination(target.transform.position);
    }
}
