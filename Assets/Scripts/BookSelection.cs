using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelection : MonoBehaviour
{
    public GameObject dialog;
    public BookShelfController controller;

    public GameObject redBook;
    public GameObject blueBook;
    public GameObject greenBook;
    public GameObject purpleBook;
    public GameObject orangeBook;

    public GameObject redBookHighlight;
    public GameObject blueBookHighlight;
    public GameObject greenBookHighlight;
    public GameObject purpleBookHighlight;
    public GameObject orangeBookHighlight;

    private List<GameObject> bookList = new List<GameObject>();
    private List<GameObject> highlights = new List<GameObject>();

    private int currentBook = 0;
    private int takenBookIndex = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        bookList.Add(redBook);
        bookList.Add(blueBook);
        bookList.Add(greenBook);
        bookList.Add(purpleBook);
        bookList.Add(orangeBook);

        highlights.Add(redBookHighlight);
        highlights.Add(blueBookHighlight);
        highlights.Add(greenBookHighlight);
        highlights.Add(purpleBookHighlight);
        highlights.Add(orangeBookHighlight);



        selectBook();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) //Platzhalter, lieber pfeiltasten?
        {
            if (currentBook == bookList.Count - 1)
            {
                currentBook = 0;
                selectBook();
            } 
            else
            {
                currentBook++;
                selectBook();
            }
        } 
        if (Input.GetKeyDown(KeyCode.J)) //Platzhalter, lieber pfeiltasten?
        {
            if (currentBook == 0)
            {
                currentBook = bookList.Count - 1 ;
                selectBook();
            } 
            else
            {
                currentBook--;
                selectBook();
            }
        }
        if (Input.GetKeyDown(KeyCode.K)) //Platzhalter
        {
            takeSelectedBook();
        }
    }

    public void selectBook() 
    {
        unselectAllHighlights();
        highlights[currentBook].SetActive(true);
    }

    private void takeSelectedBook() {
        bookList[currentBook].SetActive(false);
        bookList.RemoveAt(currentBook);
        highlights.RemoveAt(currentBook);
        takenBookIndex = currentBook;
        currentBook = 0;
        dialog.GetComponent<Dialogue>().EndDialogue();
    }

    public void unselectAllHighlights() 
    {
        for (int i = 0; i < bookList.Count; i++)
        {
            highlights[i].SetActive(false);
        }
    }

    public void resetAll() 
    {

    }

    public void setAll() 
    {
        bool[] visibleBooks = controller.getVisibleBooks();
        for (int i = 0; i < visibleBooks.Length; i++)
        {
            if (visibleBooks[i] == false)
            {
                bookList.RemoveAt(i);
            }
        }
    }

    public int getTakenBookIndex() 
    {
        return takenBookIndex;
    }
}
