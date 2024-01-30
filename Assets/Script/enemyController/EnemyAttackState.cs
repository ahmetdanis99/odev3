using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    private float attackTimer = 0f;
    private float attackDelay = 2f;
    public StateID GetID()
    {
        return StateID.Attack;
    }
    public void Enter(MainController controller)
    {
        controller.agent.speed = 0;
    }

    public void Exit(MainController controller)
    {
        controller.agent.speed = 3.5f;
    }
    public void Update(MainController controller)
    {
        float distance = Vector3.Distance(controller.enemyController.transform.position, controller.target.transform.position);
        if (distance >= 5)
        {
            controller.stateMachine.ChangeState(StateID.Chase);
        }
        else
        {
            AttackTrigger(controller);
        }
    }
    public void AttackTrigger(MainController controller)
    {

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDelay)
        {
            controller.enemyController.animate.SetTrigger("attack");
            controller.attackOn = true;
            attackTimer = 0f;
        }
    }
}
