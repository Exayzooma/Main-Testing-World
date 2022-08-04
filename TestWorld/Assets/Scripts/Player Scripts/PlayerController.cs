using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveForce = 10f;
    public float jumpForce = 11f;

    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;

    private float movementX;
    private string WALK_ANIMATION = "Walk";

    private bool IsGrounded;
    private string GROUND_TAG = "Ground";
    //public float maxVelocity = 22f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()
    {

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        //running to right side 
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        //running to left side
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            IsGrounded = true;
        }
    }


}
