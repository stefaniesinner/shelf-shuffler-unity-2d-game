using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BookshelfController</c> to choose a book from the respective 
/// bookshelf section in the bookshelf window.
/// </summary>
public class BookshelfController : MonoBehaviour
{
    [SerializeField]
    public BookshelfUIManager bookshelfUI;
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
    private int takenBookSection = -1;

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
    }


    public bool[] VisibleBooks
    {
        get { return visibleBooks; }
    }

    public int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }

    public BookshelfUIManager BookshelfUI
    {
        get { return bookshelfUI; }
    }
    public void setTakenBook(int takenBook)
    {
        takenBookIndex = takenBook;
    }

    /// <summary>
    /// Place or remove the currently selected book.
    /// </summary>
    /// <param name="takenBook"></param> is the book color that is placed
    /// <param name="isPlaced"></param> false for removing book from the current booksection, true to place book
    public void PlaceTakenBook(int takenBook, bool isPlaced)
    {
        BookshelfSectionManager currentBookSection = bookSectionScripts[currentBookshelfSectionIndex];
        takenBookIndex = takenBook;
        takenBookSection = currentBookshelfSectionIndex;

        if (takenBook == 0)
        {
            currentBookSection.RedBook.SetActive(isPlaced);
        }
        else if (takenBook == 1)
        {
            currentBookSection.BlueBook.SetActive(isPlaced);
        }
        else if (takenBook == 2)
        {
            currentBookSection.GreenBook.SetActive(isPlaced);
        }
        else if (takenBook == 3)
        {
            currentBookSection.PurpleBook.SetActive(isPlaced);
        }
        else if (takenBook == 4)
        {
            currentBookSection.OrangeBook.SetActive(isPlaced);
        }
    }
}
