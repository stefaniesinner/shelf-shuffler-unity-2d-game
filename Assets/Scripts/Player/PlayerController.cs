using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerController player;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private float moveHorizontal;
    private float moveVertical;
    private float speed = 5f;
    private float jumpingPower;

    private float groundRadius = 0.3f;
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

        FlipSprite(moveHorizontal);
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (IsJumping())
        {
            rb.velocity = new Vector2(0, jumpingPower);
        }
    }

    private void FlipSprite(float movementDirection)
    {
        Vector3 scaleOfObject = transform.localScale;

        // Move to the left
        if (movementDirection < 0)
        {
            // Flip the object's scale
            scaleOfObject.x = Mathf.Abs(scaleOfObject.x) * -1;
        }
        // Move to the right
        else if (movementDirection > 0)
        {
            // Maintain the original scale without changes
            scaleOfObject.x = Mathf.Abs(scaleOfObject.x);
        }

        transform.localScale = scaleOfObject;
    }

    private void AnimatePlayer()
    {
        anim.SetBool("isMoving", IsMoving());
        anim.SetBool("isGrounded", IsGrounded());
    }

    private bool IsMoving()
    {
        if (moveHorizontal != 0f)
        {
            return true;
        }

        return false;
    }

    private bool IsGrounded()
    {
        if (Physics2D.CircleCast(transform.position, groundRadius, Vector2.down,
            groundRayDist, groundLayer))
        {
            return true;
        }

        return false;
    }

    private bool IsJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        player = null;
    }
}