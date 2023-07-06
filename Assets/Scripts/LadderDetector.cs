using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The detector has access to the player.
 */
public class LadderDetector : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ladder>())
        {
            player.isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Ladder>())
        {
            player.isClimbing = false;
        }
    }
}
