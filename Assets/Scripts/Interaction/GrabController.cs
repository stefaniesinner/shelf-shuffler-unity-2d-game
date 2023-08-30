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
    private GameObject grabbedObject;
    [SerializeField]
    private float grabbedObjectYValue;

    private bool isGrabbing;

    private void Awake()
    {
        grab = this;
    }

    private void Update()
    {
        Grab();
        Drop();
    }

    private void Grab()
    {
        if (isGrabbing)
        {
            isGrabbing = false;
            grabbedObject.transform.parent = null;
            grabbedObject.transform.position = new Vector2(grabbedObject.transform.position.x,
                grabbedObjectYValue);
            grabbedObject = null;
        }
        else
        {
            isGrabbing = true;
            grabbedObject = InteractionController.controller.InteractionObject;
        }
    }

    private void Drop()
    {

    }

    private void OnDestroy()
    {
        grab = null;
    }
}
