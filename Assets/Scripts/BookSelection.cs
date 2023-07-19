using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelection : MonoBehaviour
{
    public GameObject redBook;
    public GameObject blueBook;
    public GameObject greenBook;
    public GameObject purpleBook;
    public GameObject orangeBook;

    private List<GameObject> bookList; 
    private int currentBook;
    // Start is called before the first frame update
    void Start()
    {
        bookList.Add(redBook);
        bookList.Add(blueBook);
        bookList.Add(greenBook);
        bookList.Add(purpleBook);
        bookList.Add(orangeBook);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectNextBook(int currentBook, int orientation) 
    {
            if (currentBook == 0)
            {
                currentBook = currentBook + orientation;
                blueBook.SetActive(false); //Platzhalter
            } 
             else if (currentBook == 1)
            {
                currentBook = currentBook + orientation;
                greenBook.SetActive(false); //Platzhalter
            }
            else if (currentBook == 2)
            {
                currentBook = currentBook + orientation;
                purpleBook.SetActive(false); //Platzhalter
            }
            else if (currentBook == 3)
            {
                currentBook = currentBook + orientation;
                orangeBook.SetActive(false); //Platzhalter
            }
            else if (currentBook == 4)
            {
                currentBook = currentBook + orientation;
                redBook.SetActive(false); //Platzhalter
            }
            else if (currentBook == 5)
            {
                currentBook = 1;
                blueBook.SetActive(false); //Platzhalter
            }
            else if (currentBook == -1)
            {
                currentBook = 3;
                purpleBook.SetActive(false);
            }
    }
    public void unselectAll() 
    {
        redBook.SetActive(true);
        blueBook.SetActive(true);
        greenBook.SetActive(true);
        purpleBook.SetActive(true);
        orangeBook.SetActive(true);
    }

    public int getCurrentSelected() 
    {
        return currentBook;
    }
}
