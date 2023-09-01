using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    private GameObject detectedObject;
    [SerializeField]
    private Transform detectionPoint;
    [SerializeField]
    private LayerMask detectionLayer;
    [SerializeField]
    private float detectionRange = 0.2f;

    private void Awake()
    {
        controller = this;
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
