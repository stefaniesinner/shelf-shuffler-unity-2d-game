using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to control the interactions between player and game object
public class InteractionController : MonoBehaviour
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

    private KeyCode giveBookKey = KeyCode.F;

    [SerializeField]
    private BookshelfController bookshelfController;

    private void Update()
    {
        Collider2D item = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayer);
        takenBook = bookshelfController.TakenBookIndex;
        sectionOfTakenBook = bookshelfController.TakenBookSection;

        if (isDetecting(item))
        {
            interactionObject.GetComponent<InteractionManager>().Interact();
        }

        GiveBookToStudent(takenBook);
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

    private void GiveBookToStudent(int book)
    {
        if (isTouchingStudent)
        {
            if (Input.GetKeyDown(giveBookKey))
            {
                Debug.Log("IS INTERACTING WITH STUDENT");
                
            }
        }
    }
    /*
    private void CompareBooks(GameObject bookFromShelf, GameObject bookStudentWished)
    {
        // Check the Color of the books
        if (takenBook.Equals(bookStudentWished)) // Rechange with Color Comparison
        {
            // Check the Section of the books
            if ()
            {
                isCorrectBook = true;
            }
            isCorrectBook = false;
        }
        isCorrectBook = false;
    } */
    

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
