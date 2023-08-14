using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to handle the player. It contains all information necessary for the user to
 * control and interact with the game character (the librarian).
 */
public class PlayerController : MonoBehaviour
{
    private bool isGrounded;
    private bool isMoving;

    private float speed = 5f;
    private float jumpingPower = 5;
    private float gravityScale;
    private float moveHorizontal;
    private float moveVertical;

    private float groundRadius = 0.3f;
    private float groundRayDist = 0.5f;

    private PlayerController player;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");

        AnimatePlayer();
        FlipSprite(moveHorizontal);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void Jump()
    {

    }

    private void FlipSprite(float xValue)
    {
        Vector2 scaleOfObject = transform.localScale;

        // Player is moving to the left
        if (xValue < 0)
        {
            // Flip the player's scale
            scaleOfObject.x = Mathf.Abs(scaleOfObject.x) * -1;
        }
        // Player is moving to the right
        else if (xValue > 0)
        {
            // Maintain the original scale without changes
            scaleOfObject.x = Mathf.Abs(scaleOfObject.x);
        }

        transform.localScale = scaleOfObject;
    }

    private void AnimatePlayer()
    {

    }

    private void OnDestroy()
    {
        player = null;
    }
}
