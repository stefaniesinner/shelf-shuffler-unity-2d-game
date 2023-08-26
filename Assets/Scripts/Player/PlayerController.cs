using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;

    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private bool isMoving;

    public int storage = 0;

    private float speed = 5f;
    private float jumpForce = 7f;
    private float moveHorizontal;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float radius = 0.3f;
    [SerializeField]
    private float groundRayDist = 0.55f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private void Start()
    {
        obj = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.game.isPaused)
        {
            moveHorizontal = 0f;
            return;
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");

        isMoving = (moveHorizontal != 0f);

        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);

        Flip(moveHorizontal);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
    }

    private void Flip(float xValue)
    {
        Vector3 theScale = transform.localScale;

        if (xValue < 0)
        {
            theScale.x = Mathf.Abs(theScale.x) * -1;
        }
        else if (xValue > 0)
        {
            theScale.x = Mathf.Abs(theScale.x);
        }

        transform.localScale = theScale;
    }

    private void OnDestroy()
    {
        obj = null;
    }
}