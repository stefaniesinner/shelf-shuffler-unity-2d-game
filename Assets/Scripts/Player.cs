using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;

    public bool isGrounded = false;
    public bool isMoving = false;

    // to control the movements of the player
    public float speed = 5f;
    public float jumpForce = 3;
    public float moveHorizontal;
    public float moveVertical;

    public LayerMask groundLayer; // to know if and which floor the player is touching
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    // to use the ladder
    private bool isLadder; // to know if the player is standing next to the ladder
    private bool isClimbing;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;


    /*
     * Implements the player.
     */
    private void Awake()
    {
        player = this;
    }

    /*
     * This method is called before updating the first frame.
     */
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    /*
     * Update the player once per frame by changing the sprites.
     */
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        isMoving = (moveHorizontal != 0);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (isLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        Flip(moveHorizontal);
    }

    /*
     * Moves the player.
     */
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
            rb.gravityScale = 3; // have an effect on players jump
        }
    }

    /*
     * ...
     */
    private void Jump()
    {
        if (!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
    }

    /*
     * Flips the sprites of our player according to where he moves (left or right).
     */
    private void Flip(float _xValue)
    {
        Vector3 theScale = transform.localScale;

        if (_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else
        if (_xValue > 0)
            theScale.x = Mathf.Abs(theScale.x);

        transform.localScale = theScale;
    }

    /*
     * Check if the player is standing to the ladder.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    /*
     * Check if the player is standing to the ladder yet.
     */
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    /*
     * ...
     */
    private void OnDestroy()
    {
        player = null;
    }

}
