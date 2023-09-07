using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>BookshelfSectionManager</c> to check from which bookshelf section
/// the respective book was taken from.
/// </summary>
public class BookshelfSectionManager : MonoBehaviour
{
    // The bookshelf section, where this Script is attached to
    [SerializeField]
    private GameObject section;
    [SerializeField]
    private BookshelfController controller;

    // The Book GameObjects that are inside this book section
    [SerializeField]
    private GameObject redBook;
    [SerializeField]
    private GameObject blueBook;
    [SerializeField]
    private GameObject greenBook;
    [SerializeField]
    private GameObject purpleBook;
    [SerializeField]
    private GameObject orangeBook;
    [SerializeField]
    private GameObject highlight;

    private bool[] visibleBooks;

    // True if this bookshelf section is currently selected
    private bool selected = false;

    private void Start()
    {
        visibleBooks = new bool[5] { true, true, true, true, true };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Sets selected true if the player touches this bookshelf section
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
        // Sets selected false if the player doesnt touch this bookshelf section
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

    /// <summary>
    /// Method to check if this bookshelf section is currently selected or not.
    /// </summary>
    /// <returns></returns>
    public bool IsSelected()
    {
        return selected;
    }

    /// <summary>
    /// Sets the visibility of GameObjects. Used to set the books inside this section.
    /// </summary>
    /// <param name="gameObject">The respective books.</param>
    /// <param name="isVisible">True if the book is inside the section.</param>
    public void SetVisible(GameObject gameObject, bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    public GameObject Section
    {
        get { return section; }
    }

    public GameObject RedBook
    {
        get { return redBook; }
    }

    public GameObject BlueBook
    {
        get { return blueBook; }
    }
    public GameObject GreenBook
    {
        get { return greenBook; }
    }
    public GameObject PurpleBook
    {
        get { return purpleBook; }
    }
    public GameObject OrangeBook
    {
        get { return orangeBook; }
    }

    public GameObject Highlight
    {
        get { return highlight; }
    }

    public bool[] VisibleBooks
    {
        get { return visibleBooks; }
    }
}
