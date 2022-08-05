    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine statemachine;

    public D_Entity entitydata;

    public int  facingdirection { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject alivego { get; private set; }

    [SerializeField]
    private Transform wallcheck;
    [SerializeField]
    private Transform ledgecheck;

    private Vector2 velocityworkspace;

    public virtual void Start()
    {
        facingdirection = 1;
        alivego = transform.Find("Alive").gameObject;
        rb = alivego.GetComponent<Rigidbody2D>();
        anim = alivego.GetComponent<Animator>();

        statemachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        statemachine.currentstate.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        statemachine.currentstate.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityworkspace.Set(facingdirection * velocity, rb.velocity.y);
        rb.velocity = velocityworkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallcheck.position, alivego.transform.right, entitydata.wallcheckdistance, entitydata.whatisground);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgecheck.position, Vector2.down, entitydata.ledgecheckdistance, entitydata.whatisground);
    }

    public virtual void Flip()
    {
        facingdirection *= -1;
        alivego.transform.Rotate(0f, 180f, 0f);
    }

   public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallcheck.position, wallcheck.position + (Vector3)(Vector2.right * facingdirection * entitydata.wallcheckdistance));
        Gizmos.DrawLine(ledgecheck.position, ledgecheck.position + (Vector3)(Vector2.down * entitydata.ledgecheckdistance));
    }
}