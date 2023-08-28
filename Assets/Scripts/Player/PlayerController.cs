using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>PlayerController</c> handles the player. It contains all information necessary
/// for the user to control and interact with the game character (the librarian).
/// </summary>
public class PlayerController : MonoBehaviour
{
    public static PlayerController player;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private float moveHorizontal;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpingPower = 7f;
    private bool isJumping;
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    private float groundRadius = 0.3f;
    [SerializeField]
    private float groundRayDist = 0.5f;
    [SerializeField]
    private LayerMask groundLayer;

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
        moveHorizontal = Input.GetAxis("Horizontal");
        
        IsMoving();
        IsGrounded();
        IsJumping();

        AnimatePlayer();
        FlipSprite(moveHorizontal);
    }

    private void FixedUpdate()
    {
        Move();

        if (isJumping)
        {
            Jump();
        }
    }

    /// <summary>
    /// Check if the player moves to the left or right.
    /// </summary>
    /// <returns>true if the player is moving to the left or right.</returns>
    private bool IsMoving()
    {
        if ((moveHorizontal != 0f))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Check if the player is on the ground.
    /// </summary>
    /// <returns>true if the player is touching the ground.</returns>
    private bool IsGrounded()
    {
        if (Physics2D.CircleCast(transform.position, groundRadius, Vector3.down,
            groundRayDist, groundLayer))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Check if the player jumps.
    /// </summary>
    private void IsJumping()
    {
        // prevents multiple jumping
        if (!IsGrounded())
        {
            return;
        }

        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
        }
    }

    /// <summary>
    /// Move to the respective direction and speed.
    /// </summary>
    private void Move()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    /// <summary>
    /// Initiate a jump with the respective jumping power.
    /// </summary>
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpingPower;
        AudioManager.aud.PlaySound(AudioManager.aud.JumpingSound);
        isJumping = false;
    }

    /// <summary>
    /// Animate the game character.
    /// </summary>
    private void AnimatePlayer()
    {
        anim.SetBool("isMoving", IsMoving());
        anim.SetBool("isGrounded", IsGrounded());
    }

    /// <summary>
    /// Flip the sprite of the game character based on whether the player is going left or right.
    /// </summary>
    /// <param name="movementDirection">Indicates the direction of movement.</param>
    private void FlipSprite(float movementDirection)
    {
        Vector3 scaleOfObject = transform.localScale;

        // move to the left
        if (movementDirection < 0)
        {
            // flip the object's scale
            scaleOfObject.x = Mathf.Abs(scaleOfObject.x) * -1;
        }
        // move to the right
        else if (movementDirection > 0)
        {
            // maintain the original scale without changes
            scaleOfObject.x = Mathf.Abs(scaleOfObject.x);
        }

        transform.localScale = scaleOfObject;
    }

    private void OnDestroy()
    {
        player = null;
    }
}