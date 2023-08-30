using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public static GrabController grab;

    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private Transform grabbedObject;
    [SerializeField]
    private float grabbedObjectYValue;

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

    }

    private void OnDestroy()
    {
        grab = null;
    }
}
