using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, GrabDrop }
    public InteractionType type;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 8; // Layer number of "Item"
    }

    public void Interact()
    {
        switch (type) 
        {
            case InteractionType.PickUp:
                // Add the object to the PickUpItems list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                // Disable the object
                gameObject.SetActive(false);
                break;
            case InteractionType.GrabDrop:
                // Grab interaction
                FindObjectOfType<InteractionSystem>().GrabDrop();
                Debug.Log("GRAB");
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
