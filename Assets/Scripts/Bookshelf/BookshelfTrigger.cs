using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to trigger the Bookshelf Window
public class BookshelfTrigger : MonoBehaviour
{
    [SerializeField]
    private KeyCode keycode;

    private bool isDetectingPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(keycode) && isDetectingPlayer)
        {

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = true;
            // ...
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = false;
            // ...
        }
    }
}
