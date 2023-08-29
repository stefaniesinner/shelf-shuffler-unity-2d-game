using UnityEngine;

/// <summary>
/// Class <c>LadderController</c> to use the ladder for reaching the books in the higher
/// shelf.
/// </summary>
public class LadderController : MonoBehaviour
{
    public static LadderController ladder;

    private bool isTouched;
    private bool isClimbed;

    private void Awake()
    {
        ladder = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouched = false;
            isClimbed = false;
        }
    }
}
