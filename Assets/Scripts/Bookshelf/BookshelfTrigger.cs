using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfTrigger : MonoBehaviour
{
    [SerializeField]
    private BookshelfController bookshelf;

    private bool isDetectingPlayer;

    private void Update()
    {
        if (isDetectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            bookshelf.ShowBookshelfWindow(isDetectingPlayer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = true;
            bookshelf.ShowButtonIndicator(isDetectingPlayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = false;
            bookshelf.ShowButtonIndicator(isDetectingPlayer);
        }
    }

}
