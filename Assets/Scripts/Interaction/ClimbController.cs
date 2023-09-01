using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public static ClimbController controller;

    private bool isTouchingLadder;

    private void Awake()
    {
        controller = this;
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
            IsClimbing = false;
        }
    }

    public bool IsTouchingLadder
    {
        get { return isTouchingLadder; }
    }

    public bool IsClimbing { get; set; }
}
