using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to show how many books are left in all bookshelf sections. Therefore, it updates 
   all book sections by removing the books from the respective section
 */
public class BookshelfController : MonoBehaviour
{
    [SerializeField]
    public BookshelfUI bookshelfUI;
    [SerializeField]
    private BookshelfHighlighter selection;
    [SerializeField]
    private BookSelectionController singleBooks;
    [SerializeField]
    private int currentBookshelfSectionIndex;
    [SerializeField]
    private bool[] visibleBooks;
    [SerializeField]
    private int takenBookIndex;
    [SerializeField]
    private int takenBookSection;

    private List<BookshelfSectionManager> bookSectionScripts = new List<BookshelfSectionManager>();


    private void Start()
    {
        bookSectionScripts = selection.BookSectionScripts;
    }

    private void Update()
    {
        currentBookshelfSectionIndex = selection.CurrentBookshelfSectionIndex;
        takenBookIndex = singleBooks.TakenBookIndex;
        if (currentBookshelfSectionIndex != -1)
        {
            visibleBooks = bookSectionScripts[currentBookshelfSectionIndex].VisibleBooks;
        }
        
        if (!bookshelfUI.GetComponent<BookshelfUI>().IsOpen)
        {
            takenBookSection = currentBookshelfSectionIndex;
        }
    }

    public bool[] VisibleBooks
    {
        get { return visibleBooks; }
    }

    public int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }
    public void setTakenBook(int takenBook)
    {
        takenBookIndex = takenBook;
    }

    public int TakenBookIndex
    {
        get { return takenBookIndex; }
    }

    public int TakenBookSection
    {
        get { return takenBookSection; }
    }
}