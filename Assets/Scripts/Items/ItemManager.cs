using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage the items and invoke their interaction with the player
public class ItemManager : MonoBehaviour
{
    public enum Interaction { NONE, GrabAndDrop }

    [SerializeField]
    private Interaction interactionType;

    public void Interact()
    {
        if (interactionType == Interaction.GrabAndDrop && Input.GetKeyDown(KeyCode.G))
        {
            FindObjectOfType<InteractionManager>().GrabAndDropItem();
            Debug.Log("GRABBED ITEM");
        }
    }

}
