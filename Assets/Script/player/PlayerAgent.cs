using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : Agent
{
    public override void Start()
    {
        base.Start();
        stateMachine.RegisterState(new PlayerIdleState());
        stateMachine.RegisterState(new PlayerChaseState());
        stateMachine.RegisterState(new PlayerDeathState());
        stateMachine.RegisterState(new PlayerAttackState());
    }
}
