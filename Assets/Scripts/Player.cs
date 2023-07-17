using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public float speed = 5f;
    public float jumpingPower = 5;
    public float gravityScale = 3;

    public LayerMask groundLayer; // To know if and which ground the player is touching
    public float groundRadius = 0.3f;
    public float groundRayDist = 0.5f;

    private float moveHorizontal;
    private float moveVertical;

    private bool isJumping;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;


    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        isMoving();

        AnimatePlayer();
        FlipSprite(moveHorizontal);
    }

    private void FixedUpdate()
    {
        isOnGround();

        Move();
        Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && !isJumping)
        {
            rb.velocity = new Vector3(0, jumpingPower, 0);
            isJumping = true;
        }

        // Stop multiple jumping at a time
        if (rb.velocity.y == 0)
        {
            isJumping = false;
        }
    }

    private bool isMoving()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal != 0)
        {
            return true;
        }

        return false;
    }

    private bool isOnGround()
    {
        if (Physics2D.CircleCast(transform.position, groundRadius, Vector3.down, groundRayDist, groundLayer))
        {
            return true;
        }

        return false;
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
        anim.SetBool("isMoving", isMoving());
        anim.SetBool("isGrounded", isOnGround());
        //anim.SetBool("isClimbing", isClimbing);
        //anim.SetBool("isVertical", isOnLadder);
    }

    private void OnDestroy()
    {
        player = null;
    }

}
