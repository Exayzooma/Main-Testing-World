using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/Idle Data/Idle State")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 0.1f;
    public float maxIdleTime = 0.2f;
}
