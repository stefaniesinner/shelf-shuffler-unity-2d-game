using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to show how man books are left in all bookshelf sections. Therefore, it updates 
   all book sections by removing the books from the respective section
 */
public class BookshelfController : MonoBehaviour
{
    private List<BookshelfSectionManager> bookSectionScripts = new List<BookshelfSectionManager>();
    private int currentBookshelfSectionIndex;
    private bool[] visibleBooks;

    public int takenBookIndex;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private bool[] VisibleBooks
    {
        get { return visibleBooks; }
    }

    private int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }
}
