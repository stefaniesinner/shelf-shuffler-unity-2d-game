using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>Player</c> contains all information necessary for the user to control and interact with the game character (the librarian).
/// </summary>
public class Player : MonoBehaviour
{

    public static Player player;

    public bool isGrounded = false;
    public bool isMoving = false;
    private bool isTouchingLadder = false;
    private bool isClimbing = false;
    private bool vertical = false;

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

    /// <summary>
    /// Construct the players' game character.
    /// </summary>
    private void Awake()
    {
        player = this;
    }

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
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
        } else if ( Mathf.Abs(moveVertical) == 0)
        {
            vertical = false;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isClimbing", isClimbing);
        anim.SetBool("isVertical", vertical);

        Flip(moveHorizontal);
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

    /// <summary>
    /// Allow the player to jump and check if he is on the ground.
    /// </summary>
    private void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        rb.velocity = Vector2.up * jumpForce;
    }

    /// <summary>
    /// Flip the sprites of the player according to his movements. If the player moves to the opposite direction (to the left), 
    /// flip the player's scale. Otherwise, maintain the original scale without changes.
    /// </summary>
    /// <param name="xDirection">The direction on the x-coordinate.</param>
    private void Flip(float xDirection)
    {
        Vector3 playerScale = transform.localScale;

        if (xDirection < 0)
        {
            playerScale.x = Mathf.Abs(playerScale.x) * -1;
        }
        else if (xDirection > 0)
        {
            playerScale.x = Mathf.Abs(playerScale.x);
        }

        transform.localScale = playerScale;
    }

    /// <summary>
    /// Check if the player is standing to the collision object.
    /// </summary>
    /// <param name="collision">The respective collision object.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isTouchingLadder = true;
        }
    }

    /// <summary>
    /// Check if the player is standing to the collision object yet.
    /// </summary>
    /// <param name="collision">The respective collision object.</param>
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
