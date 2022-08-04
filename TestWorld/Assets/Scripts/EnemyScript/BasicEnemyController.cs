using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
  private enum State
    {
        Walking,
        Knockback,
        Dead
    }

    [SerializeField]
     private Transform
         groundCheck,
         wallCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private Vector2 knockbackSpeed;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        movementSpeed,
        maxHealth,
        knockbackDuration;

    private bool
        groundDetected,
        wallDetected;

    private float currentHealth,
        knockbackStartTime;

    private int facingDirection,
        damageDirection;

    private Vector2 movement;

    private GameObject Alive;
    private Rigidbody2D AliveRb;
    private Animator Aliveanim;

    private void Start()
    {
        Alive = transform.Find("Alive").gameObject;
        AliveRb = Alive.GetComponent<Rigidbody2D>();
        Aliveanim = Alive.GetComponent<Animator>();

        facingDirection = 1;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.Knockback:
                UpdateKnockbackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }

    private State currentState;

    //-- WALKING STATE--------------------------------------------------------

  

    private void EnterWalkingState()
    {
 
    }

    private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if(!groundDetected || wallDetected)
        {
            Flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, AliveRb.velocity.y);
            AliveRb.velocity = movement;
        }
    }

    private void ExitWalkingState()
    {

    }

    //-- KNOCKBACK STATE---------------------------------------------------------

    private void EnterKnockbackState()
    {
        knockbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x * damageDirection, knockbackSpeed.y);
        AliveRb.velocity = movement;
        Aliveanim.SetBool("Knockback", true);
    }

    private void UpdateKnockbackState()
    {
        if(Time.time >= knockbackStartTime + knockbackDuration)
        {
            SwitchState(State.Walking);
        }
    }

    private void ExitKnockbackState()
    {
        Aliveanim.SetBool("Knockback", false);
    }


    //-- DEAD STATE-----------------------------------------------------------------

    private void EnterDeadState()
    {
        //Spawn chunks and blood
        Destroy(gameObject);
    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }

    //-- OTHER FUNCTIONS--------------------------------
    private void Damage(float[] attackDetails)
    {
        currentHealth -= attackDetails[0];

        if (attackDetails[1] > Alive.transform.position.x)
        {
            damageDirection = -1;
        }
        else
        {
            damageDirection = 1;
        }

        //Hit particles

        if (currentHealth > 0.0f)
        {
            SwitchState(State.Knockback);
        }
        else if (currentHealth <= 0.0f)
        {
            SwitchState(State.Dead);
        }
    }
    private void Flip()
    {
        facingDirection *= -1;
        Alive.transform.Rotate(0.0f, 189.0f, 0.0f);
    }
    private void SwitchState(State state)
    {
        switch(currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;
            case State.Knockback:
                ExitKnockbackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }

        switch (state)
        {
            case State.Walking:
                EnterWalkingState();
                break;
            case State.Knockback:
                EnterKnockbackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }

        currentState = state;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
}
