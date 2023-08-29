using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>LadderController</c> to use the ladder for reaching the books in the higher
/// shelf.
/// </summary>
public class LadderController : MonoBehaviour
{
    private static LadderController ladder;

    private Rigidbody2D rb;

    private float moveVertical;
    private float climbSpeed = 3f;

    private bool isTouchingLadder;
    private bool isClimbing;

    private void Awake()
    {
        ladder = this;
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
            isClimbing = true;
        }
    }

    private void Climb()
    {
        if (isClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * climbSpeed);
        } 
        else
        {
            rb.gravityScale = 4f;
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
}
