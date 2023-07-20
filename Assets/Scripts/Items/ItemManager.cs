using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum Interaction { NONE, GrabAndDrop }

    [SerializeField]
    private Interaction interactionType;
    [SerializeField]
    private KeyCode interactionKey;

    public void Interact()
    {
        switch (interactionType)
        {
            case Interaction.GrabAndDrop:
                FindObjectOfType<InteractionManager>().GrabAndDropItem();
                Debug.Log("GRAB");
                break;
            default:
                Debug.Log("NONE INTERACTION");
                break;
        }
    }

    public KeyCode getInteractionKey
    {
        get { return interactionKey; }
    }
}
