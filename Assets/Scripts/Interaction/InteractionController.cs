using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;
    
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private LayerMask targetLayer;
    private Collider2D targetCollision;

    [SerializeField]
    private Transform interactionPoint;
    [SerializeField]
    private float interactionRange = 0.2f;

    [SerializeField]
    private KeyCode grabKey = KeyCode.G;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(grabKey))
        {
            GrabController.grab.GrabTarget = targetObject;
            Debug.Log("GRABBED OBJECT");
        }
    }

    private void FixedUpdate()
    {
        targetCollision = Physics2D.OverlapCircle(interactionPoint.position,
            interactionRange, targetLayer);
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
