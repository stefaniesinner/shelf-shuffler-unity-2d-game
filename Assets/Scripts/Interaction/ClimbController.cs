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
    private float gravityScale;
    [SerializeField]
    private float climbSpeed = 4f;

    private bool isTouchingLadder;
    private bool isClimbing;
    private bool isVertical;

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

        CanClimb();
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            Climb();
        }
    }

    private void CanClimb()
    {
        if (isTouchingLadder)
        {
            if (Mathf.Abs(moveVertical) > 0f)
            {
                isClimbing = true;
                isVertical = true;
            }
            else if (Mathf.Abs(moveVertical) == 0f)
            {
                isVertical = false;
            }
        }
    }

    private void ChangeGravity()
    {

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
            isVertical = false;
        }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
