using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfController : MonoBehaviour
{
    // Start is called before the first frame update
    public Selection selection;
    public BookSelection singleBooks;

    public List<BookshelfSection> bookSectionScripts = new List<BookshelfSection>();
    public int currentBookshelfIndex;
    public bool[] visibleBooks;

    public int takenBookIndex;

    void Start()
    {
        bookSectionScripts = selection.getBookSectionScripts();
    }

    // Update is called once per frame
    void Update()
    {
        currentBookshelfIndex = selection.getCurrentBookshelfSectionIndex();
        if (currentBookshelfIndex != -1)
        {
            visibleBooks = bookSectionScripts[currentBookshelfIndex].getVisibleBooks();
            takenBookIndex = singleBooks.getTakenBookIndex();
        }
    }
}
