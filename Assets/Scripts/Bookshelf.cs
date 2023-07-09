using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bookshelf : MonoBehaviour
{
    public List<GameObject> books = new List<GameObject>();
    public GameObject window;

    public void PickUp(GameObject book)
    {
        books.Add(book);
    }
}
