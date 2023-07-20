using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum Interaction { NONE, GrabAndDrop }

    public Interaction interaction;

    public void Interact()
    {
        switch (interaction)
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
}
