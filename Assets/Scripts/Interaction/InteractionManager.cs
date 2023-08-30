using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager manager;

    [SerializeField]
    private KeyCode grabKey = KeyCode.G;

    private void Update()
    {
        Interact();
    }

    public void Interact()
    {
        if (Input.GetKeyUp(grabKey))
        {
            GrabController.grab.Grab();
        }
    }
}
