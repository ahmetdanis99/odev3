using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    public StateID GetID()
    {
        return StateID.Idle;
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
