using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punk : MonoBehaviour
{
    public CharacterController2D controller; 
    public Animator animator;
    public float moveForce = 10f; 

    private float movementX;

    public Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;


    private BoxCollider2D BoxCol2d; 
    public LayerMask LayerMask; 

    private void Awake()
    {
        myBody = transform.GetComponent<Rigidbody2D>();

        sr = transform.GetComponent<SpriteRenderer>();

        BoxCol2d = transform.GetComponent<BoxCollider2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        PlayerAttack();
    }

    
    void FixedUpdate()
    {
        controller.Move(movementX * Time.fixedDeltaTime, false, false);
    }

    // Function for movementX

    private void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal") * moveForce;
    }

    //Function for animating while movementX is in process

    private void AnimatePlayer()
    {

        animator.SetFloat ("Speed", Mathf.Abs(movementX));
    }

    // Function for Jump function 
    private void PlayerJump()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            float jumpVelocity = 14f;
            myBody.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("IsJumping",true);
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(BoxCol2d.bounds.center, BoxCol2d.bounds.size, 0f, Vector2.down, .1f, LayerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

       // Function for Attackfunction 
    private void PlayerAttack()
    {
        if ( Input.GetKeyDown(KeyCode.Z))
        {
     
            animator.SetBool("IsAttacking",true);
        }
    }



}

