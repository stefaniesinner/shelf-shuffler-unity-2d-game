using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    [SerializeField]
    private GameObject interactableObject;
    [SerializeField]
    private Collider2D interactableCollider; 
    [SerializeField]
    private LayerMask interactableLayer;
    [SerializeField]
    private Transform interactablePoint;
    [SerializeField]
    private float InteractableRange = 0.2f;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        if (IsDetectingObject(interactableCollider))
        {
            InteractionManager.manager.Interact();
        }
    }

    private void FixedUpdate()
    {
        interactableCollider = Physics2D.OverlapCircle(interactablePoint.position,
            InteractableRange, interactableLayer);
    }

    private bool IsDetectingObject(Collider2D collider)
    {
        if (collider != null)
        {
            interactableObject = collider.gameObject;
            return true;
        }

        return false;
    }

    public GameObject InteractableObject
    {
        get { return interactableObject; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
