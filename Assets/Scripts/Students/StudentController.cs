using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to handle the students walking into the library.
 */
public class StudentController : MonoBehaviour
{
    [SerializeField]
    private float moveHorizontal = 0f;
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private bool isGroundFloor = true;
    [SerializeField]
    private bool isGroundFront = false;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float frontGroundRayDist = 0.25f;
    [SerializeField]
    private float floorCheckY = 0.52f;
    [SerializeField]
    private float frontCheck = 0.51f;
    [SerializeField]
    private float frontDist = 0.001f;

    [SerializeField]
    private int scoreGive = 50;

    private Rigidbody2D rb;
    private RaycastHit2D hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector3(moveHorizontal, 0, 0), frontGroundRayDist, groundLayer));

        if (isGroundFloor)
        {
            moveHorizontal = moveHorizontal * -1;
        }

        if (Physics2D.Raycast(transform.position, new Vector3(moveHorizontal, 0, 0), frontCheck, groundLayer))
        {
            moveHorizontal = moveHorizontal * -1;
        }

        hit = Physics2D.Raycast(new Vector3(transform.position.x + moveHorizontal * frontCheck, transform.position.y, transform.position.z),
            new Vector3(moveHorizontal, 0, 0), frontDist);

        if (hit != null)
        {
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Student"))
                {
                    moveHorizontal = moveHorizontal * -1;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is detected");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetKilled();
            FXManager.obj.ShowPop(transform.position);
        }
    }

    private void GetKilled()
    {
        gameObject.SetActive(false);
    }
}
