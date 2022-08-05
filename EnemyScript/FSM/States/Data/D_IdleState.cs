using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/IdleState Data")]

public class D_IdleState : ScriptableObject
{
    public float minidletime = 1f;
    public float maxidletime = 2f;
}
