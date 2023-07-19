using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine, GrabDrop }
    public InteractionType type;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7; // Layer number of "Item"
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
            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                break;
            case InteractionType.GrabDrop:
                Debug.Log("GRAB");
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
