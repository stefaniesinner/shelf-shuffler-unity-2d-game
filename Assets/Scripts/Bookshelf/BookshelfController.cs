using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to show the Bookshelf Window
public class BookshelfController : MonoBehaviour
{
    public GameObject bookshelfWindow;
    public GameObject buttonIndicator; // To inform the player which button to press to open the bookshelf window

    private void Start()
    {
        ShowButtonIndicator(false);
        ShowBookshelfWindow(false);
    }

    private void Update()
    {

    }

    public void ShowBookshelfWindow(bool isShowing)
    {
        bookshelfWindow.SetActive(isShowing);
    }

    public void ShowButtonIndicator(bool isShowing)
    {
        buttonIndicator.SetActive(isShowing);
    }
}
