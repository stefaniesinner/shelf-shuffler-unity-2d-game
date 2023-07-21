using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StudentController : MonoBehaviour{

    public float studentPatience = 30.0f; 
    public int studentNeeds; 
    
    public float studentMoveSpeed = 3f; 
    //public GameObject positionDummy; 

    public int mySeat; 
    public Vector3 destination; 
    private GameObject gameController; 

    private GameObject[] availableProducts; //List of books to choose from 
    

    private float currentStudentPatience; 
    private bool isOnSeat; 
    private bool mainOrderisfulfilled; 


    /*public GameObject healthBarFG; 
    public GameObject healthBarBG; 
    private bool healthBarSliderFlag; 
    public GameObject requestBubble; 
    */
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

    private string[] sections = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };

    [SerializeField]
    private GameObject[] books;

       [SerializeField]
    private Text sectionText;
     

    void Awake(){
       
       /*
        healthBarFG.SetActive(false); 
        requestBubble.SetActive(false); 
        healthBarBG.SetActive(false); 
        */

        mainOrderisfulfilled = false; 

        isOnSeat = false; 
        currentStudentPatience = studentPatience; 
        leaveTime = 0; 
        isLeaving = false; 
        creationTime = Time.time; 
        //moodIndex = 0;
       startingPosition = transform.position; 

        gameController = GameObject.FindGameObjectWithTag("GameController"); 

        //Init(); 
        StartCoroutine(goToSeat()); 
    }
/*

void Init()
    {
       
        if (bookList != null && bookList.Count > 0)
        {
            
            GameObject selectedBook = bookList[Random.Range(0, bookList.Count)];

            GameObject askBook = Instantiate(selectedBook, positionDummy.transform.position, Quaternion.Euler(90, 180, 0));
            askBook.transform.localScale = new Vector3(0.18f, 0.1f, 0.13f);
            askBook.transform.parent = requestBubble.transform;
        }
        else
        {
            Debug.LogWarning("No books available in the bookList.");
        }
    }
*/
   

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
            /*healthBarBG.SetActive(true);
            requestBubble.SetActive(true);
            healthBarFG.SetActive(true);
            */

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

    if (sectionText != null)
    {
        sectionText.text = sections[selectedSection];
    }
}



/*
    void Update(){

        if(healthBarSliderFlag)
            StartCoroutine(healthBar()); 
            
        updateStudentMood(); 
    }

    void updateStudentMood(){
            /*
        if(!isLeaving){

            if(currentStudentPatience <= studentPatience / 2)
                    //moodIndex = 1; 
            else 
                    //moodIndex = 0; 
        }
      
    
    }
    IEnumerator healthBar()
    {
        healthBarSliderFlag = false;
        while (currentStudentPatience > 0)
        {
            currentStudentPatience -= Time.deltaTime * Application.targetFrameRate * 0.02f;
            healthBarFG.transform.localScale = new Vector3(healthBarFG.transform.localScale.x - ((0.02f / studentPatience) * Time.deltaTime * Application.targetFrameRate),
                                                             healthBarFG.transform.localScale.y,
                                                             healthBarFG.transform.localScale.z);
            healthBarFG.transform.position = new Vector3(healthBarFG.transform.position.x,
                                                           healthBarFG.transform.position.y - ((0.021f / studentPatience) * Time.deltaTime * Application.targetFrameRate),
                                                           healthBarFG.transform.position.z);
            yield return 0;
        }
        if (currentStudentPatience <= 0)
        {
            healthBarFG.GetComponent<Renderer>().enabled = false;
           
            StartCoroutine(leave());
        }

    }


    void LateUpdate(){

        if(mainOrderisfulfilled && !isLeaving){
            settle(); 
        }
    }
   
    void settle(){
        float leaveTime = Time.time; 
        int remainedPatienceBonus = (int)Mathf.Round(studentPatience- (leaveTime - creationTime)); 
        StartCoroutine(leave()); 

    }


    void fillStudentPatience(){
        currentStudentPatience = studentPatience; 

    }

    public IEnumerator leave(){
        if(isLeaving)
        yield break; 

    isLeaving = true; 
    
        //animate (close) patienceBar
        yield return new WaitForSeconds(0.3f);

        //animate (close) request bubble

        yield return new WaitForSeconds(0.4f);

    
            if (transform.position.x >= 10)
            {
                gameController.GetComponent<MainGameController>().availableSeatForStudents[mySeat] = true;
                Destroy(gameObject);
                yield break;
            }
            yield return 0;
        }
    }

    */
}

