using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    [SerializeField]
    private LayerMask interactionLayer; // Only items attaching the respective Layer can be interact with the player
    [SerializeField]
    private GameObject interactionObject;
    [SerializeField]
    private Transform interactionPoint;
    [SerializeField]
    private float interactionRange = 0.2f;

    private Collider2D item;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        item = Physics2D.OverlapCircle(interactionPoint.position, 
            interactionRange, interactionLayer);

        if (IsDetectingObject(item))
        {
            if (Input.GetKeyUp(GrabController.grab.GrabKey))
            {
                GrabController.grab.GrabAndDropItem();
            }
        }

    }

    public bool IsDetectingObject(Collider2D collider)
    {
        if (collider != null)
        {
            interactionObject = collider.gameObject;
            return true;
        }
        interactionObject = null;
        return false;
    }

    public GameObject InteractionObject
    {
        get { return interactionObject; }
    }

    public Collider2D Item
    {
        get { return item; }
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
