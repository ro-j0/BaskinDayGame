using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_2D : MonoBehaviour
{
    // Basic sprite/player inizialization for 2D character
    Animator animator;
    Rigidbody2D rb2D;
    SpriteRenderer spriterenderer;

    // Variables for player movement speed. Can be manipulated in editor
    [SerializeField]
    private float walkspeed = 4f;
    [SerializeField]
    private float runspeed = 8f;
    [SerializeField]
    private float jumpspeed = 5f;

    // Variables for jumping mechanic
    private float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;

    // Variables for Coyote time 
    public float hangTime = 0.2f;
    private float hangCounter;

    // Variables for jump buffering
    public float jumpBufferLength;
    private float jumpBufferCount;

    // Variables for ground checking logic
    bool isGrounded;
    [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;

    // Variables for main camera
    public Transform camTarget;
    public float camAheadDistance, camSpeed;
 
    // Start is called before the first frame update
    void Start()
    {
        // Initialization of player character
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        ///////////////////////////////////////////////////////////////////
        /// Implementation of ground logic. This is how we know player is
        /// eitehr on the groud (in a 2D space)
        //////////////////////////////////////////////////////////////////

        if (Physics2D.Linecast(transform.position, groundCheckL.position, 
            1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, 
            groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else
            isGrounded = false;

        ///////////////////////////////////////////////////////////////////
        /// Implementation of player movement across the X axis. Only works
        /// with keys at the moment. Can work with arrows and WASD
        //////////////////////////////////////////////////////////////////

        // Walk/Run to the right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (Input.GetKey("left shift") && isGrounded)
            {
                rb2D.velocity = new Vector2(walkspeed, rb2D.velocity.y);
                animator.Play("walk");
            }
            else
            {
                if (isGrounded == false)
                {
                    rb2D.velocity = new Vector2(runspeed - 1, rb2D.velocity.y);
                }
                else 
                { 
                    rb2D.velocity = new Vector2(runspeed, rb2D.velocity.y);
                }
                animator.Play("run");

            }
            spriterenderer.flipX = false;
        }
        // Walk/Run to the left
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (Input.GetKey("left shift") && isGrounded)
            {
                rb2D.velocity = new Vector2(-walkspeed, rb2D.velocity.y);
                animator.Play("walk");
            }
            else
            {
                if (isGrounded == false)
                {
                    rb2D.velocity = new Vector2(-runspeed + 1, rb2D.velocity.y);
                }
                else
                {
                    rb2D.velocity = new Vector2(-runspeed, rb2D.velocity.y);
                }
                animator.Play("run");
            }
            spriterenderer.flipX = true;
        }
        // Idle
        else
        {
            animator.Play("idle");
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

    }
    void Update()
    {
        // Cyote time check
        if (isGrounded)
            hangCounter = hangTime;
        else if (isJumping == false)
            hangCounter -= Time.deltaTime;
        else 
            hangCounter = 0;

        // Jump buffer check
        if (Input.GetKeyDown("space"))
            jumpBufferCount = jumpBufferLength;
        else
            jumpBufferCount -= Time.deltaTime;

        ///////////////////////////////////////////////////////////////////
        /// Implementation of player jump. Can only be executed with the
        /// space bar at the moment. There are two things that are checked
        /// before the plaeyr can jump. 1, if they're hangtime is full, and
        /// 2, if their jump buffer is greater than 0. This mens that the
        /// player is grounded, and has the means to jump. The additional
        /// jump velocity in the if statement "if (jumpTimeCounter) > 0"
        /// is meant to extend the jump to a maximum height based on the
        /// jump time counter
        //////////////////////////////////////////////////////////////////

        // initial jump mechanic is here
        if (jumpBufferCount >= 0f && hangCounter > 0f)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
            jumpBufferCount = 0f;
        }
        if (Input.GetKeyUp("space"))
        {
            isJumping = false;
        }
        if (isJumping)
        {
            // Extended jump mechanic is here
            if (jumpTimeCounter > 0)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
   
}
