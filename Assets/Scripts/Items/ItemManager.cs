using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
