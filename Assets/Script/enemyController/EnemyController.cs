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
    }

    public override void Update()
    {
        isLive = setDead(playerProps);
        if (isLive)
        {
            base.Update();
        }
        else
        {
            stateMachine.ChangeState(StateID.Death);
        }
    }
}