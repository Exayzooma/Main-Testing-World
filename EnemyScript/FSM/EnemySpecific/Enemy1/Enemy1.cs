using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idlestate { get; private set; }
    public E1_MoveState movestate { get; private set; }

    [SerializeField]
    private D_IdleState idlestatedata;
    [SerializeField]
    private D_MoveState movestatedata;

    public override void Start()
    {
        base.Start();

        movestate = new E1_MoveState(this, statemachine, "move", movestatedata, this);
        idlestate = new E1_IdleState(this, statemachine, "idle", idlestatedata, this);

        statemachine.initialize(movestate);
    }
}
