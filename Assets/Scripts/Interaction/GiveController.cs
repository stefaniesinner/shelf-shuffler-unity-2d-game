using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>GiveController</c> handles the item exchange of two game objects.
/// </summary>
public class GiveController : MonoBehaviour
{
    [SerializeField]
    private Transform transferPoint;
    [SerializeField]
    private GameObject transferPartner;
    [SerializeField]
    private KeyCode transferKey = KeyCode.G;

    private float takenBook;
    private float takenBookSection;

    private bool isCorrectBook;

    private void Update()
    {
        takenBook = BookshelfController.controller.TakenBookIndex;
        takenBookSection = BookshelfController.controller.TakenBookSection;

        if (InteractionController.controller.IsDetectingObject)
        {
            if (Input.GetKeyDown(transferKey)
                && InteractionController.controller.DetectedObject == transferPartner)
            {
                CompareBook();

                if (isCorrectBook)
                {
                    Debug.Log("CORRECT BOOK");
                    GiveBook();
                }
                else
                {
                    Debug.Log("WRONG BOOK");
                    // TODO: Invoke an event where students get angry
                }
            }
        }
    }

    private void GiveBook()
    {

    }

    private void CompareBook()
    {

    }
}
