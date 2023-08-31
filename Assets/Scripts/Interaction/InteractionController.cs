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

    private KeyCode grabKey = KeyCode.G;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        Collider2D item = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayer);

        if (isDetecting(item))
        {
            if (Input.GetKeyDown(grabKey))
            {
                GrabController.controller.GrabAndDropItem();
            }
        }

    }

    private bool isDetecting(Collider2D collider)
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

}
