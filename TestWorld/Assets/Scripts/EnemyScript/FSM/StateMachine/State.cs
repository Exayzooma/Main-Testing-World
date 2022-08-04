using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine statemachine;
    protected Entity entity;

    protected float starttime;
    protected string animboolname;

    public State(Entity entity, FiniteStateMachine statemachine, string animboolname)
    {
        this.entity = entity;
        this.statemachine = statemachine;
        this.animboolname = animboolname;
    }

    public virtual void Enter()
    {
        starttime = Time.time;
        entity.anim.SetBool(animboolname, true);
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animboolname, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
