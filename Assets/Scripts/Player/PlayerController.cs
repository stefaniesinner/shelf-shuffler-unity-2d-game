using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController player;
    
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpingPower = 5;
    [SerializeField]
    private float gravityScale;
    private float moveHorizontal;
    private float moveVertical;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundRadius = 0.3f;
    [SerializeField]
    private float groundRayDist = 0.5f;

    private bool isJumping;
    private bool isTouchingLadder;
    private bool isClimbing;
    private bool isOnLadder;

    private Rigidbody2D rb2D;
    private Animator anim;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        isMoving();
        isOnGround();
        isUsingLadder();

        FlipSprite(moveHorizontal);
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        ClimbLadder();
    }

    private void Move()
    {
        rb2D.velocity = new Vector2(moveHorizontal * speed, rb2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb2D.velocity = new Vector2(0, jumpingPower);
            isJumping = true;
        }

        // Stop multiple jumping at a time
        if (rb2D.velocity.y == 0)
        {
            isJumping = false;
        }
    }

    private void ClimbLadder()
    {
        if (isClimbing)
        {
            rb2D.gravityScale = 0f;
            rb2D.velocity = new Vector2(rb2D.velocity.x, moveVertical * speed);
        }
        else
        {
            rb2D.gravityScale = gravityScale;
        }
    }

    private bool isMoving()
    {
        if (moveHorizontal != 0)
        {
            return true;
        }

        return false;
    }

    private bool isOnGround()
    {
        if (Physics2D.CircleCast(transform.position, groundRadius, Vector2.down, groundRayDist, groundLayer))
        {
            return true;
        }

        return false;
    }

    private bool isUsingLadder()
    {
        if (isTouchingLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
            isOnLadder = true;
        }
        else if (Mathf.Abs(moveVertical) == 0)
        {
            isOnLadder = false;
        }

        return false;
    }

    private void FlipSprite(float xValue)
    {
        Vector2 scaleOfPlayer = transform.localScale;

        // Move to the left
        if (xValue < 0)
        {
            // Flip the player's scale
            scaleOfPlayer.x = Mathf.Abs(scaleOfPlayer.x) * -1;
        }
        // Move to the right
        else if (xValue > 0)
        {
            // Maintain the original scale without changes
            scaleOfPlayer.x = Mathf.Abs(scaleOfPlayer.x);
        }

        transform.localScale = scaleOfPlayer;
    }

    private void AnimatePlayer()
    {
        anim.SetBool("isMoving", isMoving());
        anim.SetBool("isGrounded", isOnGround());
        anim.SetBool("isClimbing", isClimbing);
        anim.SetBool("isVertical", isOnLadder);
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
