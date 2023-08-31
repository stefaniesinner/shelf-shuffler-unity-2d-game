using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabController : MonoBehaviour
{
    public static GrabController grab;

    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private GameObject grabbedItem;
    [SerializeField]
    private float grabbedItemYValue;

    private bool isGrabbing;

    private KeyCode grabKey = KeyCode.G;

    private void Awake()
    {
        grab = this;
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
            grabbedItem = InteractionController.controller.InteractionObject;
            grabbedItem.transform.parent = transform;
            grabbedItemYValue = grabbedItem.transform.position.y;
            grabbedItem.transform.localPosition = grabPoint.localPosition;
        }
    }

    public KeyCode GrabKey
    {
        get { return grabKey; }
    }
}
