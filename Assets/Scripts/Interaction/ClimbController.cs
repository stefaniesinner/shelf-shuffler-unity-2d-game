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

    private Rigidbody2D rb; // of the player

    private float moveVertical;
    [SerializeField]
    private float climbSpeed;
    private const float climbGravityScale = 0f;
    private float originalGravityScale;
    
    private bool isTouchingLadder;
    private bool isVertical;
    private bool isClimbing;

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
            DisableGravity();
            Climb();
        }

        if (!isClimbing)
        {
            RestoreGravity();
        }
    }

    /// <summary>
    /// Check if the player is allowed to climb.
    /// </summary>
    private void CanClimb()
    {
        if (isTouchingLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
            isVertical = true;
        }

        if (Mathf.Abs(moveVertical) == 0f)
        {
            isVertical = false;
        }
    }

    /// <summary>
    /// Climb the respective object.
    /// </summary>
    private void Climb()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveVertical * climbSpeed);
    }

    /// <summary>
    /// Disable the gravity to enable climbing on the respective object. Before 
    /// changing gravity for the first time, save the player's original gravity scale.
    /// </summary>
    private void DisableGravity()
    {
        if (rb.gravityScale != climbGravityScale)
        {
            originalGravityScale = rb.gravityScale;
        }

        rb.gravityScale = climbGravityScale;
    }

    /// <summary>
    /// Restore the gravity after disabling it by resetting it to its original value.
    /// </summary>
    private void RestoreGravity()
    {
        if (rb.gravityScale == climbGravityScale)
        {
            rb.gravityScale = originalGravityScale;
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

    public bool IsVertical
    {
        get { return isVertical; }
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
