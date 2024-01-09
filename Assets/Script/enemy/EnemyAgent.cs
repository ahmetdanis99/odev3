using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : Agent
{
    public override void Start()
    {
        base.Start();
        stateMachine.RegisterState(new EnemyIdleState());
        stateMachine.RegisterState(new EnemyChaseState());
        stateMachine.RegisterState(new EnemyDeathState());
        stateMachine.RegisterState(new EnemyAttackState());
        initialState = StateID.Idle;
        stateMachine.ChangeState(initialState);
    }
}
