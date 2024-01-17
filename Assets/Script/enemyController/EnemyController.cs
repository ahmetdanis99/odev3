using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MainController
{
    public override void Start()
    {
        base.Start();
        enemyController = GetComponent<EnemyController>();
        stateMachine.RegisterState(new EnemyIdleState());
        stateMachine.RegisterState(new EnemyChaseState());
        stateMachine.RegisterState(new EnemyDeathState());
        stateMachine.RegisterState(new EnemyAttackState());
        initialState = StateID.Idle;
        stateMachine.ChangeState(initialState);
    }
}
