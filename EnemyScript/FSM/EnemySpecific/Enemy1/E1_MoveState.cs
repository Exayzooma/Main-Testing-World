using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{

    private Enemy1 enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine statemachine, string animboolname, D_MoveState statedata, Enemy1 enemy) : base(entity, statemachine, animboolname, statedata)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isdetectingwall || isdetectingledge)
        {
            enemy.idlestate.SetFlipAfterIdle(true);
            statemachine.changestate(enemy.idlestate);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
