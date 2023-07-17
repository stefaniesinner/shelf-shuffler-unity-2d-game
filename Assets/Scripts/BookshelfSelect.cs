using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfSelect : MonoBehaviour
{
    //Get Bookshelf ParentObject
    //public GameObject Bookshelf;
    public GameObject Books;
    //Variable selectedField
    //List with all books, order important

    // Start is called before the first frame update
    void Start()
    {
        //call loadBooks
        loadBooks();
    }

    // Update is called once per frame
    void Update()
    {
        //if the collider in bookshelf is finding something
        //set selectedField to first books ->get it from List
        //highlight selected field
    }

    void loadBooks()
    {
        //2 For Loop according to Shelf position
        //Instantiate(); TODO How to get prefab object?
        //Instantiate every Books at right position
        //make it an child of bookshelf
        //Add to list
        /**
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                int x;
                int y;
                int z;
                Instantiate(Books, new Vector3(-1.329, -0.04, 0.01457022), Quaternion.identity, transform);
            }
        }
        **/
        Instantiate(Books, new Vector3(-1.329f, -0.04f, 0.01457022f), Quaternion.identity, transform);

    }
}
