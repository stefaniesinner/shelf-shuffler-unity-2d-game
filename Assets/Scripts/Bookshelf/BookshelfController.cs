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
    private int takenBookSection = - 1;

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

    public BookshelfUI BookshelfUI
    {
        get { return bookshelfUI; }
    }
    public void setTakenBook(int takenBook)
    {
        takenBookIndex = takenBook;
    }

    public void removeTakenBook(int takenBook)
    {
        BookshelfSectionManager currentBookSection = bookSectionScripts[currentBookshelfSectionIndex];
        takenBookIndex = takenBook;
        takenBookSection = currentBookshelfSectionIndex;

        if (takenBook == 0)
        {
            currentBookSection.RedBook.SetActive(false);
        } 
        else if (takenBook == 1)
        {
            currentBookSection.BlueBook.SetActive(false);
        } 
        else if (takenBook == 2)
        {
            currentBookSection.GreenBook.SetActive(false);
        }
        else if (takenBook == 3)
        {
            currentBookSection.PurpleBook.SetActive(false);
        }
        else if (takenBook == 4)
        {
            currentBookSection.OrangeBook.SetActive(false);
        }
    }

}