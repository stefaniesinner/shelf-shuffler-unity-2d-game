using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public static ClimbController controller;

    private bool isTouchingLadder;
    private bool isClimbing;

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
            isClimbing = false;
        }
    }

    public bool IsTouchingLadder
    {
        get { return isTouchingLadder; }
    }

    public bool IsClimbing
    {
        get { return isClimbing; }
        set { isClimbing = value; }
    }
}
