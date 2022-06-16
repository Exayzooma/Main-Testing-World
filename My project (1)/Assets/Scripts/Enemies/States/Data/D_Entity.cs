using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckdistance = 0.2f;
    public float ledgeCheckdistance = 0.4f;

    public LayerMask whatIsGround;
}
