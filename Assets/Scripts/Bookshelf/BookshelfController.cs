using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle the Bookshelf Window
public class BookshelfController : MonoBehaviour
{
    [SerializeField]
    private GameObject bookshelfWindow;
    [SerializeField]
    private GameObject buttonIndicator; // To inform the player which button to press to open/close the bookshelf window

    private bool isDetectingPlayer;

    private void Start()
    {
        ShowBookshelfWindow(false);
        ShowBookshelfWindow(false);
    }

    private void Update()
    {
        if (isDetectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            bookshelfWindow.SetActive(true);
        }
    }

    private void ShowBookshelfWindow(bool isShowing)
    {
        bookshelfWindow.SetActive(isShowing);
    }

    private void ShowButtonIndicator(bool isShowing)
    {
        buttonIndicator.SetActive(isShowing);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = true;
            ShowButtonIndicator(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = false;
            ShowButtonIndicator(false);
        }
    }

    private void OnDestroy()
    {
        bookshelfWindow = null;
        buttonIndicator = null;
    }

}
