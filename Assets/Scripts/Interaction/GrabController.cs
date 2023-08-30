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
    private GameObject grabTarget;

    private float grabTargetYPosition;

    private bool isGrabbing;

    private void Awake()
    {
        grab = this;
    }

    private void Update()
    {
        Grab();
    }

    private void Grab()
    {
        if (isGrabbing)
        {
            isGrabbing = false;
            grabTarget.transform.parent = null;
            grabTarget.transform.position = new Vector2(grabTarget.transform.position.x,
                grabTargetYPosition);
            grabTarget = null;
        }
        else
        {
            isGrabbing = true;
            grabTarget = InteractionController.controller.TargetObject;
            grabTarget.transform.parent = transform;
            grabTargetYPosition = grabTarget.transform.position.y;
            grabTarget.transform.localPosition = grabPoint.localPosition;
        }
    }

    public GameObject GrabTarget
    {
        set { grabTarget = value; }
    }

    private void OnDestroy()
    {
        grab = null;
    }
}
