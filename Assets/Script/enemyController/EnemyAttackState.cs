using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    public StateID GetID()
    {
        return StateID.Attack;
    }
    public void Enter(MainController controller)
    {
    }

    public void Exit(MainController controller)
    {
    }
    public void Update(MainController controller)
    {
    }
}
