using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>ClimbController</c> handles the ladder climbing. All objects possessing this
/// component are able to climb the ladder.
/// </summary>
public class ClimbController : MonoBehaviour
{
    public static ClimbController controller;

    private Rigidbody2D rb;

    private void Awake()
    {
        controller = this;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        controller = null;
    }
}
