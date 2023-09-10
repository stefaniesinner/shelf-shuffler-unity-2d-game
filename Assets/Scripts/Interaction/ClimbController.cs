using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>ClimbController</c> handles the ladder climbing. All objects possessing this
/// component are able to climb the ladder.
/// </summary>
public class ClimbController : MonoBehaviour
{
    public static ClimbController controller;

    private Rigidbody2D rb;

    private float moveVertical;
    [SerializeField]
    private float climbSpeed = 4f;
    private float gravityScale;

    private bool isTouchingLadder;
    private bool isClimbingLadder;

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
        if (isClimbingLadder)
        {
            rb.gravityScale = 0f;
            Climb();
        }

        if (!isClimbingLadder)
        {
            rb.gravityScale = 4f;
        }

        if (Mathf.Abs(moveVertical) == 0f)
        {
            isTouchingLadder = false;
        }
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
        rb.velocity = new Vector2(rb.velocity.x, moveVertical * climbSpeed);
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

    public bool IsClimbingLadder
    {
        get { return isClimbingLadder; }
    }

    public bool IsTouchingLadder
    {
        get { return isTouchingLadder; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
