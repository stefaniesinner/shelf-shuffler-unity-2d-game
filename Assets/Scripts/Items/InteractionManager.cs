using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask detectionLayer; // Only objects attaching the respective Layer can be interact with the player
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

    private bool isDetecting;
    private bool isGrabbing;

    private void Update()
    {
        Collider2D item = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        OnTriggerEnter2D(item);

        if (isDetecting)
        {
            detectedItem.GetComponent<ItemManager>().Interact();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            isDetecting = true;
            detectedItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null)
        {
            isDetecting = false;
        }
    }

    private void OnDestroy()
    {
        detectedItem = null;
    }

}
