using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to choose a book from the respective bookshelf section in the bookshelf window
public class BookSelectionController : MonoBehaviour
{
    [SerializeField]
    private BookshelfController controller;
    [SerializeField]
    private BookshelfHighlighter highlighter;

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
    private GameObject redBookHighlight;
    [SerializeField]
    private GameObject blueBookHighlight;
    [SerializeField]
    private GameObject greenBookHighlight;
    [SerializeField]
    private GameObject purpleBookHighlight;
    [SerializeField]
    private GameObject orangeBookHighlight;
    [SerializeField]
    private int currentBook = 0;

    private List<GameObject> bookList;
    private List<GameObject> highlights = new List<GameObject>();
    private int takenBookIndex = -1;

    private void Start()
    {
        bookList = new List<GameObject>();
        bookList.Add(redBook);
        bookList.Add(blueBook);
        bookList.Add(greenBook);
        bookList.Add(purpleBook);
        bookList.Add(orangeBook);

        highlights = new List<GameObject>();
        highlights.Add(redBookHighlight);
        highlights.Add(blueBookHighlight);
        highlights.Add(greenBookHighlight);
        highlights.Add(purpleBookHighlight);
        highlights.Add(orangeBookHighlight);

        SelectBook();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Platzhalter, lieber pfeiltasten?
        {
            if (currentBook == bookList.Count - 1)
            {
                currentBook = 0;
                SelectBook();
            }
            else
            {
                currentBook++;
                SelectBook();
            }
        }
        if (Input.GetKeyDown(KeyCode.J)) // Platzhalter, lieber pfeiltasten?
        {
            if (currentBook == 0)
            {
                currentBook = bookList.Count - 1;
                SelectBook();
            }
            else
            {
                currentBook--;
                SelectBook();
            }
        }
        if (Input.GetKeyDown(KeyCode.K)) // Platzhalter
        {
            TakeSelectedBook(currentBook);
        }
        if (Input.GetKeyDown(KeyCode.Q)) //controller.GetComponent<BookshelfUI>().isOpen
        {
            ResetAll();
            SetAll();
        }
        
    }

    private void SelectBook()
    {
        UnselectAllHighlights();
        highlights[currentBook].SetActive(true);
    }

    private void TakeSelectedBook(int takenBook)
    {
        bookList[takenBook].SetActive(false);
       // bookList.RemoveAt(currentBook);
       // highlights.RemoveAt(currentBook);
        takenBookIndex = currentBook;
        currentBook = 0;
        //controller.GetComponent<BookshelfUI>().OpenAndCloseBookshelfWindow();
        controller.removeTakenBook(takenBook);
    }

    private void UnselectAllHighlights()
    {
        for (int i = 0; i < bookList.Count; i++)
        {
            highlights[i].SetActive(false);
        }
    }

    public void ResetAll()
    {
        for (int i = 0; i < bookList.Count; i++)
        {
            bookList[i].SetActive(true);
            highlights[i].SetActive(false);
        }
        takenBookIndex = -1;
        currentBook = 0;
    }

    public void SetAll()
    {
        bool[] visibleBooks = controller.VisibleBooks;
        for (int i = 0; i < bookList.Count; i++)
        {
            bookList[i].SetActive(visibleBooks[i]);
        }
    }

    public int TakenBookIndex
    {
        get { return takenBookIndex; }
    }
}
