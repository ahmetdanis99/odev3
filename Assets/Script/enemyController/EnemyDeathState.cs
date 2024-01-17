using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : State
{
    public StateID GetID()
    {
        return StateID.Death;
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
