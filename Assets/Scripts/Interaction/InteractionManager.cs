using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private KeyCode grabKey = KeyCode.G;

    private void Update()
    {
        
    }

    private void Interact()
    {
        if (Input.GetKeyUp(grabKey))
        {

        }
    }
}
