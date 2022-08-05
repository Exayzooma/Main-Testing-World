using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    private Enemy1 enemy;
    public E1_IdleState(Entity entity, FiniteStateMachine statemachine, string animboolname, D_IdleState statedata, Enemy1 enemy) : base(entity, statemachine, animboolname, statedata)
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

        if(isidletimeover)
        {
            statemachine.changestate(enemy.movestate);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
