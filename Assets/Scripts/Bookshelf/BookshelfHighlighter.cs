using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle the highlighting of the currently selected bookshelf section
public class BookshelfHighlighter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bookshelfSectionObjects;
    [SerializeField]
    private List<BookshelfSectionManager> bookshelfSectionScripts = new List<BookshelfSectionManager>();
    private BookshelfSectionManager currentBookshelfSection;
    private int currentBookshelfSectionIndex;
    
    private void Start()
    {

    }

    private void Update()
    {

    }

    private void ResetAllHighlights()
    {

    }

    private void SetBookshelfSectionScripts()
    {

    }

    public BookshelfSectionManager CurrentBookshelfSection
    {
        get { return currentBookshelfSection; }
    }

    public int CurrentBookshelfSectionIndex
    {
        get { return currentBookshelfSectionIndex; }
    }

}
