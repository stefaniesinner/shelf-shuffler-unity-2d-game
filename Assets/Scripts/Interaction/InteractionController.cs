using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Class <c>InteractionController</c> handles the interaction between player and object.
/// The player is able to detect and interact with the respective object.
/// </summary>
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

    /// <summary>
    /// Check if there is an object to interact with.
    /// </summary>
    /// <param name="collision">collider of the object to interact with.</param>
    private void DetectObject(Collider2D collision)
    {
        if (collision != null)
        {
            detectedObject = collision.gameObject;
            isDetectingObject = true;
            Debug.Log("IS DETECTING OBJECT");
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
