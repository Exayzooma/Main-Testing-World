using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine 
{
    public State currentstate { get; private set; }

    public void initialize(State startingstate)
    {
        currentstate = startingstate;
        currentstate.Enter();
    }

    public void changestate(State newstate)
    {
        currentstate.Exit();
        currentstate = newstate;
        currentstate.Enter();
    }
}
