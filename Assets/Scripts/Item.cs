using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, GrabDrop }
    public enum Color { Red, Green, Blue, }
    public InteractionType type;

    public UnityEvent customEvent;

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
            case InteractionType.GrabDrop:
                // Grab interaction
                FindObjectOfType<InteractionSystem>().GrabDrop();
                Debug.Log("GRAB");
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }

        // Invoke (call) of custom event
        customEvent.Invoke();
    }
}
