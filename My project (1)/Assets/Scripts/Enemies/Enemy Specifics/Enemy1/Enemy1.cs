using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState { get; private set; }
    public E1_MoveState MoveState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;


    public override void Start()
    {
        base.Start();

        MoveState = new E1_MoveState(this, stateMachine, "Move", moveStateData, this);
        IdleState = new E1_IdleState(this, stateMachine, "Idle", idleStateData, this);

        stateMachine.Initialize(MoveState);
        Debug.Log(stateMachine.currentState);
    }
}
