using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BookshelfUIManager</c> to handle the bookshelf window.
/// </summary>
public class BookshelfUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bookshelfWindow;
    [SerializeField]
    private BookSelectionController bookSelectionController;
    [SerializeField]
    private KeyCode windowKey = KeyCode.E;

    private bool isDetectingPlayer;
    private bool isOpen;

    private void Start()
    {
        ActivateBookshelfWindow(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(windowKey))
        {
            OpenBookshelfWindow();
        }
    }

    public void OpenBookshelfWindow()
    {
        if (!isOpen && isDetectingPlayer)
        {
            isOpen = true;
            bookshelfWindow.SetActive(true);
        }
        else
        {
            isOpen = false;
            bookshelfWindow.SetActive(false);
        }
    }

    private void ActivateBookshelfWindow(bool isShowing)
    {
        bookshelfWindow.SetActive(isShowing);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDetectingPlayer = false;
        }
    }

    public bool IsOpen
    {
        get { return isOpen; }
    }

    private void OnDestroy()
    {
        bookshelfWindow = null;
    }
}
