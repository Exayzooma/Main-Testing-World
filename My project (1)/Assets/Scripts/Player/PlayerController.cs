using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float jumpforce = 10f;
    public float GroundCheckRadius;
    public Animator animator;
    public Transform GroundCheck;
    public LayerMask WhatisGround;

    private float movementInputdirection;
    private bool playerflip = true;
    private bool isGrounded;
    private bool canJump;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckFacingDirection();
        AnimatePlayer();
        CheckifcanJump();

    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    //Checking Surroundings

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatisGround);
    }

    //change facing direction when moving
    private void CheckFacingDirection()
    {
        if(playerflip && movementInputdirection < 0)
        {
            Flip();
        }
        else if (!playerflip && movementInputdirection > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        playerflip = !playerflip;
        transform.Rotate(0f, 180f, 0f);
    }


    //movement 
    private void CheckInput()
    {
        movementInputdirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputdirection, rb.velocity.y);
    }

    //jump
    private void Jump()
    {
        if (canJump)
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

    }

    private void CheckifcanJump()
    {
        if (isGrounded && rb.velocity.y <=0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    //Function for animating movement player 

    private void AnimatePlayer()
    {
        animator.SetFloat("Speed", Mathf.Abs(movementInputdirection));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
    }
}
