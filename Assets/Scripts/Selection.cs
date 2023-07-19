using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public GameObject[] bookSectionArray;
    private BookshelfSection currentSelectedSection;

    // Start is called before the first frame update
    void Start()
    {
        bookSectionArray = GameObject.FindGameObjectsWithTag("Books");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bookSectionArray.Length; i++)
        {
            BookshelfSection section = bookSectionArray[i].GetComponent<BookshelfSection>();
            if (section.isSelected() == true)
            {
                section.setVisible(section.getHighlight(), true);
                currentSelectedSection = section;
            } else {
                section.setVisible(section.getHighlight(), false);
                currentSelectedSection = null;
            }
        }
    }

    void resetAllHighlights() {
        for (int i = 0; i < bookSectionArray.Length; i++)
        {
            BookshelfSection section = bookSectionArray[i].GetComponent<BookshelfSection>();
            section.setVisible(section.getHighlight(), false);
        }
    }

    public BookshelfSection getCurrentBookshelfSection() 
    {
        return currentSelectedSection;
    }
}
