using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to handle the highlighting of the currently selected Bookshelf section
public class Selection : MonoBehaviour
{
    //Array of all Bookshelf section GameObjects
    public GameObject[] bookSectionObjects;
    //List of all Bookshelf section Scripts
    public List<BookshelfSection> bookshelfSectionScripts = new List<BookshelfSection>();
    //The Bookshelf section that is currently selected. Can be null
    private BookshelfSection currentSelectedSection;
    //The index of the current Bookshelf section. Can be null
    private int currentBookshelfSectionIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Puts all Bookshelf Objects inside bookSectionObjects
        bookSectionObjects = GameObject.FindGameObjectsWithTag("Books");
        setBoockshelfSectionScripts();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if any sections are selected or not.
        for (int i = 0; i < bookSectionObjects.Length; i++)
        {
            if (bookshelfSectionScripts[i].isSelected() == true)
            {
                bookshelfSectionScripts[i].setVisible(bookshelfSectionScripts[i].getHighlight(), true);
                currentSelectedSection = bookshelfSectionScripts[i];
                currentBookshelfSectionIndex = i;
                return;
            } else {
                bookshelfSectionScripts[i].setVisible(bookshelfSectionScripts[i].getHighlight(), false);
            }
            currentSelectedSection = null;
            currentBookshelfSectionIndex = -1;
        }
    }

    void resetAllHighlights() {
        for (int i = 0; i < bookSectionObjects.Length; i++)
        {
            BookshelfSection section = bookSectionObjects[i].GetComponent<BookshelfSection>();
            bookshelfSectionScripts[i].setVisible(bookshelfSectionScripts[i].getHighlight(), false);
        }
    }

    private void setBoockshelfSectionScripts() 
    {
        for (int i = 0; i < bookSectionObjects.Length; i++)
        {
            bookshelfSectionScripts.Add(bookSectionObjects[i].GetComponent<BookshelfSection>());
        }
    }

    public int getCurrentBookshelfSectionIndex() 
    {
        return currentBookshelfSectionIndex;
    }

    public List<BookshelfSection> getBookSectionScripts()
    {
        return bookshelfSectionScripts;
    }
}
