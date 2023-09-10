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

    private bool isTouchingLadder;
    private bool isClimbing;
    private bool isOnLadder;

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

        IsUsingLadder();
    }

    private void FixedUpdate()
    {
        Climb();
    }

    private bool IsUsingLadder()
    {
        if (isTouchingLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
            isOnLadder = true;
        }
        else if (Mathf.Abs(moveVertical) == 0f)
        {
            isOnLadder = false;
        }

        return false;
    }

    private void Climb()
    {
        if (isClimbing)
        {
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

    public bool IsOnLadder
    {
        get { return isOnLadder; }
    }

    public bool IsClimbing
    {
        get { return isClimbing; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
