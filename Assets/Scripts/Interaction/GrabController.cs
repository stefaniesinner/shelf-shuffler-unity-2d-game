using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabController : MonoBehaviour
{
    public static GrabController controller;

    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private GameObject grabbedObject;
    [SerializeField]
    private float grabbedObjectYPosition;

    private bool isGrabbing;

    private void Awake()
    {
        controller = this;
    }

    private void Grab()
    {

    }

    private void Drop()
    {

    }

    private void OnDestroy()
    {
        controller = null;
    }
}
