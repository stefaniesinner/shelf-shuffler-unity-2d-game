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

    [SerializeField]
    private GameObject waitingPoint;

    [SerializeField]
    private float moveSpeed = 4f;

    private bool isTouchingPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();

        if (isTouchingPoint)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            isTouchingPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            isTouchingPoint = false;
        }
    }
}
