using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage the interactions between player and item
public class InteractionController : MonoBehaviour
{
    [SerializeField]
    private LayerMask detectionLayer; // Only items attaching the respective Layer can be interact with the player
    [SerializeField]
    private GameObject detectedItem;
    [SerializeField]
    private Transform detectionPoint;
    [SerializeField]
    private float detectionRadius = 0.2f;

    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private GameObject grabbedItem;
    [SerializeField]
    private float grabbedItemYValue;

    private bool isGrabbing;

    private void Update()
    {
        Collider2D item = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (isDetecting(item))
        {
            detectedItem.GetComponent<InteractionManager>().Interact();
        }
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
            grabbedItem = detectedItem;
            grabbedItem.transform.parent = transform;
            grabbedItemYValue = grabbedItem.transform.position.y;
            grabbedItem.transform.localPosition = grabPoint.localPosition;
        }
    }

    private bool isDetecting(Collider2D collider)
    {
        if (collider != null)
        {
            detectedItem = collider.gameObject;
            return true;
        }

        detectedItem = null;

        return false;
    }

    private void OnDestroy()
    {
        detectedItem = null;
    }

}
