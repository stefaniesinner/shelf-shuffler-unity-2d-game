using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>GrabController</c> handles the grabbing and dropping of objects.
/// </summary>
public class GrabController : MonoBehaviour
{
    public static GrabController controller;

    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private GameObject grabbedObject;
    [SerializeField]
    private KeyCode grabKey = KeyCode.G;

    private float grabbedObjectYPosition;

    private bool isGrabbing;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        if (InteractionController.controller.IsDetectingObject)
        {
            if (Input.GetKeyDown(grabKey))
            {
                Grab();
            }
        }
    }

    /// <summary>
    /// Grab the respective object. If the object is already grabbed, drop it.
    /// </summary>
    private void Grab()
    {
        if (isGrabbing)
        {
            isGrabbing = false;
            grabbedObject.transform.parent = null;
            grabbedObject.transform.position = new Vector2(grabbedObject.transform.position.x,
                grabbedObjectYPosition);
            grabbedObject = null;
        }
        else
        {
            isGrabbing = true;
            grabbedObject = InteractionController.controller.DetectedObject;
            grabbedObject.transform.parent = transform;
            grabbedObjectYPosition = grabbedObject.transform.position.y;
            grabbedObject.transform.localPosition = grabPoint.localPosition;
        }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
