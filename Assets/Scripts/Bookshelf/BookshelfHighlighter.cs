using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BookshelfHighlighter</c> to handle the highlighting of 
/// the currently selected bookshelf section.
/// </summary>
public class BookshelfHighlighter : MonoBehaviour
{
    // Array of all Bookshelf section GameObjects
    [SerializeField]
    private GameObject[] bookSectionObjects;
    // List of all Bookshelf section Scripts
    [SerializeField]
    private List<BookshelfSectionManager> bookshelfSectionScripts = new List<BookshelfSectionManager>();
    // The Bookshelf section that is currently selected. Can be null
    [SerializeField]
    private BookshelfSectionManager currentSelectedSection;
    // The index of the current Bookshelf section. Can be null
    private int currentBookshelfSectionIndex;

    private void Start()
    {
        // Puts all Bookshelf Objects inside bookSectionObjects
        bookSectionObjects = GameObject.FindGameObjectsWithTag("Books");
        SetBookshelfSectionScripts();
    }

    private void Update()
    {
        // Checking if any sections are selected or not
        for (int i = 0; i < bookSectionObjects.Length; i++)
        {
            if (bookshelfSectionScripts[i].IsSelected() == true)
            {
                bookshelfSectionScripts[i].SetVisible(bookshelfSectionScripts[i].Highlight, true);
                currentSelectedSection = bookshelfSectionScripts[i];
                currentBookshelfSectionIndex = i;
                return;
            }
            else
            {
                bookshelfSectionScripts[i].SetVisible(bookshelfSectionScripts[i].Highlight, false);
            }
            currentSelectedSection = null;
            currentBookshelfSectionIndex = -1;
        }
    }

    private void ResetAllHighlights()
    {
        for (int i = 0; i < bookSectionObjects.Length; i++)
        {
            BookshelfSectionManager section = bookSectionObjects[i].GetComponent<BookshelfSectionManager>();
            bookshelfSectionScripts[i].SetVisible(bookshelfSectionScripts[i].Highlight, false);
        }
    }

    private void SetBookshelfSectionScripts()
    {
        for (int i = 0; i < bookSectionObjects.Length; i++)
        {
            bookshelfSectionScripts.Add(bookSectionObjects[i].GetComponent<BookshelfSectionManager>());
        }
    }

    public List<BookshelfSectionManager> BookSectionScripts
    {
        get { return bookshelfSectionScripts; }
    }

    public int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }
}
