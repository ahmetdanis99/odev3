using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
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
        controller.agent.stoppingDistance = 3;
    }

    public void Exit(MainController controller)
    {
        controller.agent.speed = 5;
        controller.agent.stoppingDistance = 0;
    }
    public void Update(MainController controller)
    {

        if (controller.playerController.KeyMove() == true || controller.target == null)
        {
            controller.stateMachine.ChangeState(StateID.Chase);
        }
        if (controller.target != null)
        {
            float distance = Vector3.Distance(controller.playerController.transform.position, controller.target.transform.position);
            if (distance >= 3)
            {
                controller.stateMachine.ChangeState(StateID.Chase);
            }
            AttackTrigger(controller);
        }

    }
    public void AttackTrigger(MainController controller)
    {

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDelay)
        {
            controller.playerController.animate.SetTrigger("attack");
            controller.attackOn = true;
            attackTimer = 0f;
        }
    }
}
