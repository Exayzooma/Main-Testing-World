using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState statedata;

    protected bool isdetectingwall;
    protected bool isdetectingledge;

    public MoveState(Entity entity, FiniteStateMachine statemachine, string animboolname, D_MoveState statedata) : base(entity, statemachine, animboolname)
    {
        this.statedata = statedata;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(statedata.movementspeed);

        isdetectingledge = entity.CheckLedge();
        isdetectingwall = entity.CheckWall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isdetectingledge = entity.CheckLedge();
        isdetectingwall = entity.CheckWall();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();


    }
}
