using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager manager;

    private void Awake()
    {
        manager = this;
    }

    private void Interact()
    {

    }

    private void OnDestroy()
    {
        manager = null;
    }
}
