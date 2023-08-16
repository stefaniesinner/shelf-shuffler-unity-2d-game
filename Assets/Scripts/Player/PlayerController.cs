using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to handle the player. It contains all information necessary for the user to
 * control and interact with the game character (the librarian).
 */
public class PlayerController : MonoBehaviour
{
    private static PlayerController obj;

    private bool isGrounded;
    private bool isMoving;

    private float speed = 5f;
    private float jumpForce = 3f;
    private float moveHorizontal;

    private LayerMask groundLayer;
    private float radius = 0.3f;
    private float groundRayDist = 0.5f;

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
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
