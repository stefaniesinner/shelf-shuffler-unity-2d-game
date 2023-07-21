using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to manage the game object and invoke their interaction with the player
public class InteractionManager : MonoBehaviour
{
    public enum Interaction { NONE, GrabAndDrop, GiveBook }

    [SerializeField]
    private Interaction interactionType;

    private KeyCode grabKey = KeyCode.G;

    public void Interact()
    {
        if (interactionType == Interaction.GrabAndDrop)
        {
            if (Input.GetKeyDown(grabKey))
            {
                FindObjectOfType<InteractionController>().GrabAndDropItem();
                Debug.Log("GRABBED ITEM");
            }
        }
    }

}
