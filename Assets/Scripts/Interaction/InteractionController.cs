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

    private void Update()
    {
        Collider2D item = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayer);

        if (isDetecting(item))
        {
            interactionObject.GetComponent<InteractionManager>().Interact();
        }

        GiveBookToStudent();
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

    private void OnDestroy()
    {
        interactionObject = null;
    }

    private void GiveBookToStudent(GameObject book)
    {
        if (isTouchingStudent)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CheckBook(book);
            }
        }
    }

    // Check if it is the book the student wants
    private bool CheckBook(GameObject book)
    {
        /*
        if ()
        {
            Debug.Log("BOOK IS CORRECT");
            return true;
        }

        Debug.Log("BOOK IS WRONG");
        */
        return false;
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
}
