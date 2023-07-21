using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to choose a book from the respective bookshelf section in the bookshelf window
public class BookController : MonoBehaviour
{
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

    private GameObject redBookHighlight;
    private GameObject blueBookHighlight;
    private GameObject greenBookHighlight;
    private GameObject purpleBookHighlight;
    private GameObject orangeBookHighlight;

    private List<GameObject> bookList = new List<GameObject>();
    private List<GameObject> highlights = new List<GameObject>();

    private int currentBook = 0;
    private int takenBookIndex = -1;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    
    private void SelectBook()
    {

    }

    private void TakeSelectedBook()
    {

    }

    private void UnselectAllHighlights()
    {

    }

    private void ResetAll()
    {

    }

    private void SetAll()
    {

    }

    private int TakenBookIndex
    {
        get { return takenBookIndex; }
    }
}
