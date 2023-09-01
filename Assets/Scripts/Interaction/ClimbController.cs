using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public static ClimbController controller;

    private Rigidbody2D rb;

    private bool isTouchingLadder;
    private bool isClimbingLadder;

    private float moveVertical;
    private float gravityScale;
    [SerializeField]
    private float climbSpeed = 3f;

    private void Awake()
    {
        controller = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVertical = Input.GetAxisRaw("Vertical");

        IsClimbing();
    }

    private void FixedUpdate()
    {
        Climb();
    }

    private void IsClimbing()
    {
        if (isTouchingLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbingLadder = true;
        }
    }

    private void Climb()
    {
        if (isClimbingLadder)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = 2f;
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
            isClimbingLadder = false;
        }
    }
}
