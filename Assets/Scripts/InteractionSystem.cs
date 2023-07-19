using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    // Detection Point
    public Transform detectionPoint;
    // Detection Radius
    private const float detectionRadius = 0.2f;
    // Detection Layer
    public LayerMask detectionLayer;
    // Cached Trigger Object
    public GameObject detectedObject;
    // List of picked Items
    public List<GameObject> pickedItems = new List<GameObject>();

    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;
    public bool isGrabbing;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }

    public void GiveItem(int id)
    {
        Debug.Log($"GIVED AWAY {pickedItems[id].name} to Student");
        // Invoke the custom event
        pickedItems[id].GetComponent<Item>().customEvent.Invoke();
        // Clear the item from the list
        pickedItems.Remove(pickedItems[id]);
        // Destroy the item

    }

    public void GrabDrop()
    {
        // Check if we do have a grabbed object
        if (isGrabbing)
        {
            // Make the isGrabbing false
            isGrabbing = false;
            // Unparent the grabbed Object
            grabbedObject.transform.parent = null;
            // Set the y position to its origin
            grabbedObject.transform.position =
                new Vector3(grabbedObject.transform.position.x, grabbedObjectYValue, grabbedObject.transform.position.z);
            // null the grabbed object reference
            grabbedObject = null;
        }
        // Check if we have nothing grabbed grab the detected item
        else
        {
            // Enable the isGrabbing bool
            isGrabbing = true;
            // Assign the grabbed object to the object itself
            grabbedObject = detectedObject;
            // Parent the grabbed object to the player
            grabbedObject.transform.parent = transform;
            // Cache the y value of the object
            grabbedObjectYValue = grabbedObject.transform.position.y;
            // Adjust the position of the grabbed object to be closer to hands
            grabbedObject.transform.localPosition = grabPoint.localPosition;
        }
    }
}
