using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int facingDirection { get; private set; }

    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public Rigidbody2D rb { get; private set; }

    public Animator anim { get; private set; }

    public GameObject GO { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform LedgeCheck;

    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        GO = transform.Find("Healthy").gameObject;
        rb = GO.GetComponent<Rigidbody2D>();
        anim = GO.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, GO.transform.right, entityData.wallCheckDistance, entityData.whatIsGound);

    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(LedgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGound);
    }

    public virtual void Flip()
    {
        facingDirection *=1;
        GO.transform.Rotate(0f, 180f, 0f);
    }
}