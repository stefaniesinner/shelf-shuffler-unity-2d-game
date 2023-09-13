using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Class <c>StudentController</c> handles the students walking into the library.
/// </summary>
public class StudentController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    private float moveHorizontal;
    [SerializeField]
    private float moveSpeed = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CanMove();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private bool CanMove()
    {
        if (moveHorizontal != 0f)
        {
            return true;
        }

        return false;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }

    private void Enqueue()
    {
        
    }
}
