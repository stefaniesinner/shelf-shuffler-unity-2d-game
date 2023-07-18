using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfSection : MonoBehaviour
{
    //Get Bookshelf ParentObject
    //public GameObject Bookshelf;
    public GameObject section;

    public GameObject redBook;
    public GameObject blueBook;
    public GameObject greenBook;
    public GameObject purpleBook;
    public GameObject orangeBook;
    public GameObject highlight;
    private bool selected = false;

    //Variable selectedField
    //List with all books, order important

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if the collider in bookshelf is finding something
        //set selectedField to first books ->get it from List
        //highlight selected field
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we triggered the player enable playerdetected and show indicator
        if (collision.tag == "Player")
        {
            //setVisible(highlight, true);
            selected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If we lost trigger with the player disable playerdetected and hide indicator
        if (collision.tag == "Player")
        {
            //setVisible(highlight, false);
            selected = false;
        }
    }

    public bool isSelected() {
        return selected;
    }

    public void setVisible(GameObject gameObject, bool isVisible) {
        gameObject.SetActive(isVisible);
    }

    public GameObject getCurrentSelected() {
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
}
