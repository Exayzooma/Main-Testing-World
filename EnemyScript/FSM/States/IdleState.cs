using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState statedata;

    protected bool flipafteridle;
    protected bool isidletimeover;

    protected float idletime;

    public IdleState(Entity entity, FiniteStateMachine statemachine, string animboolname, D_IdleState statedata) : base(entity, statemachine, animboolname)
    {
        this.statedata = statedata;

        entity.SetVelocity(0f);
    }

    public override void Enter()
    {
        base.Enter();
        isidletimeover = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipafteridle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= starttime + idletime)
        {
            isidletimeover = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipafteridle = flip;
    }

    private void SetRandomIdleTime()
    {
        idletime = Random.Range(statedata.minidletime, statedata.maxidletime);
    }
}
