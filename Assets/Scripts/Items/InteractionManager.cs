using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage the items and invoke their interaction with the player
public class InteractionManager : MonoBehaviour
{
    public enum Interaction { NONE, GrabAndDrop }

    [SerializeField]
    private Interaction interactionType;

    [SerializeField]
    private KeyCode grabKey = KeyCode.G;

    public void Interact()
    {
        if (interactionType == Interaction.GrabAndDrop && Input.GetKeyDown(grabKey))
        {
            FindObjectOfType<InteractionController>().GrabAndDropItem();
            Debug.Log("GRABBED ITEM");
        }
    }

}
