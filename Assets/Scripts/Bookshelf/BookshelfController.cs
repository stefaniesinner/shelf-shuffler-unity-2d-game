using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to show how many books are left in all bookshelf sections. Therefore, it updates 
   all book sections by removing the books from the respective section
 */
public class BookshelfController : MonoBehaviour
{
    [SerializeField]
    private BookshelfUI bookshelfUI;
    [SerializeField]
    private BookshelfHighlighter selection;
    [SerializeField]
    private BookSelectionController singleBooks;

    private List<BookshelfSectionManager> bookSectionScripts = new List<BookshelfSectionManager>();
    private int currentBookshelfSectionIndex;
    private bool[] visibleBooks;

    private int takenBookIndex;

    private void Start()
    {
        bookSectionScripts = selection.BookSectionScripts;
    }

    private void Update()
    {
        currentBookshelfSectionIndex = selection.CurrentBookshelfSectionIndex;
        if (currentBookshelfSectionIndex != -1)
        {
            visibleBooks = bookSectionScripts[currentBookshelfSectionIndex].VisibleBooks;
        }
        /*
        if (!bookshelfUI.GetComponent<BookshelfUI>().IsOpen)
        {
            takenBookIndex = singleBooks.TakenBookIndex;
        }*/
    }

    public bool[] VisibleBooks
    {
        get { return visibleBooks; }
    }

    public int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }
}