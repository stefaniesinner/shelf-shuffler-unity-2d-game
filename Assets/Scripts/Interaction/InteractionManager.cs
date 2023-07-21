using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage the interactions between player and item
public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactionLayer; // Only items attaching the respective Layer can be interact with the player
    [SerializeField]
    private GameObject interactionObject;
    [SerializeField]
    private Transform interactionPoint;
    [SerializeField]
    private float interactionRange = 0.2f;

    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private GameObject grabbedItem;
    [SerializeField]
    private float grabbedItemYValue;

    private bool isGrabbing;

    // Student variables
    private bool isTouchingStudent;

    private int takenBook; // Book the player chose from Bookshelf and is currently holding
    private int sectionOfTakenBook;
    private bool isCorrectBook; // Taken book from the shelf is equals to the book which the student wished

    // TEST WERTE
    private int wishedBook = 0; // TEST WERTE => should be replaced with Students book wishes
    private int sectionOfWishedBook = 7; // TEST WERTE => should be replaced with Students book wishes

    private KeyCode giveBookKey = KeyCode.F;

    [SerializeField]
    private BookshelfController bookshelfController;

    private void Update()
    {
        Collider2D objectToInteract = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayer);

        takenBook = bookshelfController.TakenBookIndex;
        sectionOfTakenBook = bookshelfController.TakenBookSection;

        if (isDetecting(objectToInteract))
        {
            interactionObject.GetComponent<InteractionManager>().Interact();
        }

        InteractWithStudent();
    }

    private bool isDetecting(Collider2D collider)
    {
        if (collider != null)
        {
            interactionObject = collider.gameObject;
            return true;
        }

        interactionObject = null;

        return false;
    }

    public void GrabAndDropItem()
    {
        if (isGrabbing)
        {
            isGrabbing = false;
            grabbedItem.transform.parent = null;
            grabbedItem.transform.position = new Vector2(grabbedItem.transform.position.x, grabbedItemYValue);
            grabbedItem = null;
        }
        else
        {
            isGrabbing = true;
            grabbedItem = interactionObject;
            grabbedItem.transform.parent = transform;
            grabbedItemYValue = grabbedItem.transform.position.y;
            grabbedItem.transform.localPosition = grabPoint.localPosition;
        }
    }

    // Method to interact with Student
    private void InteractWithStudent()
    {
        // Method to Interact with the Student
        if (isTouchingStudent)
        {
            if (Input.GetKeyDown(giveBookKey))
            {
                Debug.Log("IS INTERACTING WITH STUDENT");
                CompareBooks(takenBook, sectionOfTakenBook, wishedBook, sectionOfWishedBook);

                if (!isCorrectBook)
                {
                    Debug.Log("WRONG BOOK");
                    // TODO: Invoke an event => students get angry
                }

                if (isCorrectBook)
                {
                    Debug.Log("CORRECT BOOK");
                    GiveBookToStudent(takenBook, sectionOfTakenBook);
                    isCorrectBook = false;
                }
            }
        }
    }

    // Method to compare the book selected from the shelf to the book which the students want
    private void CompareBooks(int bookFromShelf, int sectionFromShelf, int bookStudentWished, int sectionStudentWished)
    {
        if (HasEqualColor(bookFromShelf, bookStudentWished))
        {
            if (HasEqualSection(sectionFromShelf, sectionStudentWished))
            {
                isCorrectBook = true;
                return;
            }

            Debug.Log("BUT HAS EQUAL COLOR...");
        }

        isCorrectBook = false;
    }

    // Checks if the book which the player is holding has the same color like the book the student wants
    private bool HasEqualColor(int bookFromShelf, int bookStudentWished)
    {
        if (bookFromShelf == bookStudentWished)
        {
            return true;
        }
        return false;
    }

    // Checks if the book which the player is holding is from the same bookshelf section like the book the student wants
    private bool HasEqualSection(int sectionFromShelf, int sectionStudentWished)
    {
        if (sectionFromShelf == sectionStudentWished)
        {
            return true;
        }
        return false;
    }

    private void GiveBookToStudent(int book, int section)
    {
        // TODO: Delete Object
        // TODO: Invoke an event...
        Debug.Log("STUDENT GOES HOME");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Student"))
        {
            isTouchingStudent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Student"))
        {
            isTouchingStudent = false;
        }
    }

    private void OnDestroy()
    {
        interactionObject = null;
    }

}
