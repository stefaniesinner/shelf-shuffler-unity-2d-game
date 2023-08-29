using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>LadderController</c> to use the ladder for reaching the books in the higher
/// shelf.
/// </summary>
public class LadderController : MonoBehaviour
{
    public static LadderController ladder;

    private Rigidbody rb;

    private float moveVertical;
    [SerializeField]
    private float climbSpeed = 3f;

    private bool isTouched;
    private bool isUsed;

    private void Awake()
    {
        ladder = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Climb();
    }

    private void Climb()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnDestroy()
    {
        ladder = null;
    }
}
