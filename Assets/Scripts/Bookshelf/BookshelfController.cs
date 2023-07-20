using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to show the Bookshelf Window
public class BookshelfController : MonoBehaviour
{
    [SerializeField]
    private GameObject bookshelfWindow;
    [SerializeField]
    private GameObject buttonIndicator; // To inform the player which button to press to open the window
    [SerializeField]
    private KeyCode openKey = KeyCode.E;

    private bool isDetectingPlayer;

    private void Start()
    {
        ShowBookshelfWindow(false);
        ShowButtonIndicator(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(openKey) && isDetectingPlayer) // + when player is next to bookshelf!!
        {
            ShowBookshelfWindow(true);
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = true;
            ShowButtonIndicator(isDetectingPlayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = false;
            ShowButtonIndicator(isDetectingPlayer);
        }
    }
}
