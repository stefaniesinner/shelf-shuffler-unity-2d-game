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

    [SerializeField]
    private KeyCode grabKey = KeyCode.G;

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
        if (Input.GetKeyDown(grabKey))
        {
            
        }
    }

    private void OnDestroy()
    {
        grab = null;
    }
}
