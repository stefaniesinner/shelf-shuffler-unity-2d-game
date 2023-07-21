using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle the highlighting of the currently selected bookshelf section
public class BookshelfHighlighter : MonoBehaviour
{
    private GameObject[] bookshelfSectionObjects;
    private List<BookshelfManager> bookshelfSectionScripts = new List<BookshelfManager>();
    private BookshelfManager currentBookshelfSection;
    private int currentBookshelfSectionIndex;
    
    private void Start()
    {
        // Puts all Bookshelf Objects inside bookshelfSectionObjects
        bookshelfSectionObjects = GameObject.FindGameObjectsWithTag("Books");
        SetBookshelfSectionScripts();
    }

    private void Update()
    {
        // Checking if any sections are selected or not
        for (int i = 0; i < bookshelfSectionObjects.Length; i++)
        {
            // ...
        }
    }

    private void ResetAllHighlights()
    {
        for (int i = 0; i < bookshelfSectionObjects.Length; i++)
        {
            BookshelfSection section = bookshelfSectionObjects[i].GetComponent<BookshelfSection>();
            //bookshelfSectionScripts[i].setVisible(bookshelfSectionScripts[i].getHighlight(), false);
        }
    }

    private void SetBookshelfSectionScripts()
    {
        for (int i = 0; i < bookshelfSectionObjects.Length; i++)
        {
            bookshelfSectionScripts.Add(bookshelfSectionObjects[i].GetComponent<BookshelfManager>());
        }
    }

    public BookshelfManager CurrentBookshelfSection
    {
        get { return currentBookshelfSection; }
    }

    public int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }

}
