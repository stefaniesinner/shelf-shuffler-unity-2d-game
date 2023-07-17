using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private enum LadderPart { complete, bottom, top };
    [SerializeField] LadderPart part = LadderPart.complete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            switch (part)
            {
                case LadderPart.complete:
                    player.canClimb = true;
                    break;
                case LadderPart.bottom:
                    player.bottomLadder = true;
                    break;
                case LadderPart.top:
                    player.topLadder = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            switch (part)
            {
                case LadderPart.complete:
                    player.canClimb = false;
                    break;
                case LadderPart.bottom:
                    player.bottomLadder = false;
                    break;
                case LadderPart.top:
                    player.topLadder = false;
                    break;
                default:
                    break;
            }
        }
    }
}
