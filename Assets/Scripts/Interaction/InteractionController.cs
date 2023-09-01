using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    private GameObject detectedObject;

    private Collider2D detectionCollision;
    [SerializeField]
    private Transform detectionPoint;
    [SerializeField]
    private LayerMask detectionLayer;

    [SerializeField]
    private float detectionRange = 0.2f;

    private bool isDetectingObject;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        DetectObject(detectionCollision);
    }

    private void FixedUpdate()
    {
        detectionCollision = Physics2D.OverlapCircle(detectionPoint.position,
            detectionRange, detectionLayer);
    }
    
    private void DetectObject(Collider2D collision)
    {
        if (collision != null)
        {
            detectedObject = collision.gameObject;
            isDetectingObject = true;
        }
        else
        {
            detectedObject = null;
            isDetectingObject = false;
        }
    }

    public GameObject DetectedObject
    {
        get { return detectedObject; }
    }

    public bool IsDetectingObject
    {
        get { return isDetectingObject; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
