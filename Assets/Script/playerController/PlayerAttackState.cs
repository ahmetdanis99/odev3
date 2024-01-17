using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
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
        if (controller.playerController.KeyMove() == true){
            controller.stateMachine.ChangeState(StateID.Chase);
        }
    }
}
