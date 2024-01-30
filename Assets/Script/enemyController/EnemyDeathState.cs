using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : State
{
    private float dieTimer = 2f;
    public StateID GetID()
    {
        return StateID.Death;
    }
    public void Enter(MainController controller)
    {
        controller.deathTrigger(controller.enemyController.gameObject);
    }
    public void Exit(MainController controller)
    {
    }
    public void Update(MainController controller)
    {
        dieTimer -= Time.deltaTime;

        if (dieTimer <= 0)
        {
            controller.deathTrigger(controller.enemyController.gameObject);
        }
    }
}
