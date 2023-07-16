using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public bool isGrounded;
    public bool isMoving;
    private bool isTouchingLadder;
    private bool isClimbing;
    private bool vertical;

    public float moveHorizontal;
    public float moveVertical;
    public float speed = 5f;
    public float jumpForce = 3;

    // To know if and which floor the player is touching
    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;


    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.velocity = Vector2.up * jumpForce;
    }

    private void FlipSprite(float xDirection)
    {
        Vector3 scaleOfPlayer = transform.localScale;

        // Moves to the left
        if (xDirection < 0)
        {
            // Flip the player's scale
            scaleOfPlayer.x = Mathf.Abs(scaleOfPlayer.x) * -1;
        }
        // Moves to the right
        else if (xDirection > 0)
        {
            // Maintain the original scale without changes
            scaleOfPlayer.x = Mathf.Abs(scaleOfPlayer.x);
        }

        transform.localScale = scaleOfPlayer;
    }

    private void AnimatePlayer()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isClimbing", isClimbing);
        anim.SetBool("isVertical", vertical);
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        isMoving = (moveHorizontal != 0);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (isTouchingLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
            vertical = true;
        }
        else if (Mathf.Abs(moveVertical) == 0)
        {
            vertical = false;
        }

        AnimatePlayer();

        FlipSprite(moveHorizontal);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);


        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * speed);
        }
        else
        {
            rb.gravityScale = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isTouchingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isTouchingLadder = false;
            isClimbing = false;
        }
    }

    private void OnDestroy()
    {
        player = null;
    }

}
