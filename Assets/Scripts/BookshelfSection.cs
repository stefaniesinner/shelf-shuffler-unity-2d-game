using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to handle BookshelfSection Attributes
public class BookshelfSection : MonoBehaviour
{
    //The BookshelfSection GameObject, where this Script is attached to
    public GameObject section;

    //The Book GameObjects that are inside this BookSection
    public GameObject redBook;
    public GameObject blueBook;
    public GameObject greenBook;
    public GameObject purpleBook;
    public GameObject orangeBook;
    public GameObject highlight;

    public bool[] visibleBooks;


    //True if this bookshelf section is currently selected
    private bool selected = false;


    // Start is called before the first frame update
    void Start()
    {
        visibleBooks = new bool[5] {true, true, true, true, true};
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sets selected true if the player touches this bookshelf section
        if (collision.tag == "Player")
        {
            selected = true;
            visibleBooks = new bool[5] 
            {
                 this.redBook.activeSelf, this.blueBook.activeSelf, this.greenBook.activeSelf,
                 this.purpleBook.activeSelf, this.orangeBook.activeSelf
            };
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Sets selected false if the player doesnt touch this bookshelf section
        if (collision.tag == "Player")
        {
            selected = false;
            visibleBooks = new bool[5] 
            {
                this.redBook.activeSelf, this.blueBook.activeSelf, this.greenBook.activeSelf,
                this.purpleBook.activeSelf, this.orangeBook.activeSelf
            };
        }
    }

    //Method to check if this bookshelf section is currently selected or not
    public bool isSelected() {
        return selected;
    }

    //Sets the visibility of GameObjects. Used to set the books inside this section.
    public void setVisible(GameObject gameObject, bool isVisible) {
        gameObject.SetActive(isVisible);
    }

    //Gets this Bookshelf section GameObject
    public GameObject getBookShelfSection() {
        return section;
    }

    public GameObject getRedBook() {
        return redBook;
    }

    public GameObject getBlueBook() {
         return blueBook;
    }

    public GameObject getGreenBook() {
        return greenBook;
    }

    public GameObject getPurpleBook() {
        return purpleBook;
    }

    public GameObject getOrangeBook() {
        return orangeBook;
    }

    public GameObject getHighlight() {
        return highlight;
    }

    public bool[] getVisibleBooks()
    {
        return visibleBooks;
    } 
}
