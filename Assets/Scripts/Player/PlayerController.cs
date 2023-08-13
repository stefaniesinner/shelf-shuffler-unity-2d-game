using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to handle the player. It contains all information necessary for the user to
 * control and interact with the game character (the librarian).
 */
public class PlayerController : MonoBehaviour
{
    public static PlayerController player;

    private Rigidbody2D rb;
    private Animator anim;
    private LayerMask groundLayer;

    private float speed = 5f;
    private float jumpingPower = 5;
    private float gravityScale;
    private float moveHorizontal;
    private float moveVertical;

    private float groundRadius = 0.3f;
    private float groundRayDist = 0.5f;

    private bool isJumping;
    private bool isTouchingLadder;
    private bool isClimbing;

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
        
    }

    private void FixedUpdate()
    {
        
    }

    private void Move()
    {

    }

    private void Jump()
    {

    }

    private bool isMoving()
    {
        return false;
    }

    private bool isOnGround()
    {
        return false;
    }

    private void FlipSprite(float xValue)
    {

    }

    private void AnimatePlayer()
    {

    }

    private void OnDestroy()
    {
        player = null;
    }
}
