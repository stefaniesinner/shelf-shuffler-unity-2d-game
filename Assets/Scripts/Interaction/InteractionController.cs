using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController controller;

    private void Awake()
    {
        controller = this;
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
