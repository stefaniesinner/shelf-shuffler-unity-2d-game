using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Class <c>StudentController</c> handles the students walking into the library.
/// </summary>
public class StudentController : MonoBehaviour
{
    public float studentHealth = 100;
    public SatisificationBarManager healthBar;
    public int studentNeeds;

    public float studentMoveSpeed = 3f;
    //public GameObject positionDummy; 

    public int mySeat;
    public Vector3 destination;
    private GameObject gameController;

    private GameObject[] availableProducts; //List of books to choose from 


    private bool isOnSeat;

    internal float leaveTime;
    private float creationTime;
    private bool isLeaving;
    public GameObject score3DText;

    private Vector3 startingPosition;
    private Vector3 specificStartingPosition;


    [SerializeField]
    private GameObject redBook;
    [SerializeField]
    private GameObject blueBook;
    [SerializeField]
    private GameObject greenBook;
    [SerializeField]
    private GameObject purpleBook;
    [SerializeField]
    private GameObject orangeBook;

    private int selectedSection;

    private int selectedBook;
    public string[] sections = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };

    [SerializeField]
    private GameObject[] books;


    [SerializeField]
    private string[] bookLetters;

    [SerializeField]
    private TMP_Text[] sectionTextPrefabs;


    public TMP_Text[] GetSectionTextPrefabs()
    {
        return sectionTextPrefabs;
    }


    void Awake()
    {

        isOnSeat = false;
        leaveTime = 0;
        isLeaving = false;
        creationTime = Time.time;
        startingPosition = transform.position;

        gameController = GameObject.FindGameObjectWithTag("GameController");

        StartCoroutine(goToSeat());
    }

    public GameObject[] GetBooks()
    {
        return books;
    }



    private float timeVariance;


    IEnumerator goToSeat()
    {
        while (!isOnSeat)
        {
            float step = studentMoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (Vector3.Distance(transform.position, destination) < 0.001f)
            {
                isOnSeat = true;


                transform.rotation = Quaternion.Euler(0, 180, 0);

                selectedSection = Random.Range(0, 19);
                selectedBook = Random.Range(0, 4);
                ShowRandomBookOnStudent();

                yield break;
            }
            yield return 0;
        }
    }
    public void ShowRandomBookOnStudent()
    {
        for (int i = 0; i < books.Length; i++)
        {
            books[i].SetActive(i == selectedBook);
        }


    }

    public int GetSelectedSection()
    {
        return selectedSection;
    }

    public string[] GetSections()
    {
        return sections;
    }
    public string[] GetBookLetters()
    {
        return bookLetters;
    }


    public void TakeDamage(float damageAmount)
    {
        studentHealth -= damageAmount;
        healthBar.SetHealth((int)studentHealth);

        if (studentHealth <= 0)
        {
            LeaveSeatAndGoAway();
        }
    }


    private void LeaveSeatAndGoAway()
    {
        healthBar.gameObject.SetActive(false);
        StartCoroutine(MoveAwayAfterDelay());
    }

    IEnumerator MoveAwayAfterDelay()
    {
        // Wait for 10 seconds before starting to move away
        yield return new WaitForSeconds(10f);


        if (isLeaving)
        {
            yield break;
        }

        isLeaving = true;

        Vector3 targetPosition = new Vector3(4.80f, -2.50f, 0f);
        float moveSpeed = 2;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Destroy the character GameObject after moving away
        Destroy(gameObject);
    }
}
