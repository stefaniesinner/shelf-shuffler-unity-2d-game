using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager manager;

    private KeyCode grabKey = KeyCode.G;

    private void Awake()
    {
        manager = this;
    }

    public void Interact()
    {
        if (Input.GetKeyDown(grabKey))
        {
            FindObjectOfType<InteractionController>().GrabAndDropItem();
            Debug.Log("GRABBED ITEM");
        }
    }

}
