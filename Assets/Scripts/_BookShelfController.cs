using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfController : MonoBehaviour
{

    public Dialogue dialogueScript;
    public Selection selection;
    public BookSelection singleBooks;

    public List<BookshelfSection> bookSectionScripts = new List<BookshelfSection>();
    public int currentBookshelfSectionIndex;
    public bool[] visibleBooks;

    public int takenBookIndex;

    void Start()
    {
        bookSectionScripts = selection.getBookSectionScripts();
    }

    // Update is called once per frame
    void Update()
    {
        currentBookshelfSectionIndex = selection.getCurrentBookshelfSectionIndex();
        if (currentBookshelfSectionIndex != -1)
        {
            visibleBooks = bookSectionScripts[currentBookshelfSectionIndex].getVisibleBooks();
        }
        if (false) //On Dialogue close
        {
            takenBookIndex = singleBooks.getTakenBookIndex();
        }
    }

    public bool[] getVisibleBooks()
    {
        return visibleBooks;
    }

    public int getCurrentBookshelfSectionIndex()
    {
        return currentBookshelfSectionIndex;
    }
}
