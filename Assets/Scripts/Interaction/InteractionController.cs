using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    [SerializeField]
    private Transform interactionPoint;
    [SerializeField]
    private float interactionRange = 0.2f;

    private Collider2D targetCollision;
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private LayerMask targetLayer;

    private bool isDetectingObject;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        IsDetecting(targetCollision);
    }

    private void FixedUpdate()
    {
        targetCollision = Physics2D.OverlapCircle(interactionPoint.position,
            interactionRange, targetLayer);
    }

    private void IsDetecting(Collider2D collider)
    {
        if (collider != null)
        {
            targetObject = collider.gameObject;
            isDetectingObject = true;
        }
        else
        {
            targetObject = null;
            isDetectingObject = false;
        }
    }

    public bool IsDetectingObject
    {
        get { return isDetectingObject; }
    }

    public GameObject TargetObject
    {
        get { return targetObject; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
