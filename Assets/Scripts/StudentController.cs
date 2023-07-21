using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StudentController : MonoBehaviour{

    public float studentPatience = 30.0f; 
    public int studentNeeds; 
    
    public float studentMoveSpeed = 3f; 
    public GameObject positionDummy; 

    public int mySeat; 
    public Vector3 destination; 
    private GameObject gameController; 

    private GameObject[] availableProducts; //List of books to choose from 
    
    private float currentStudentPatience; 
    private bool isOnSeat; 
    private bool mainOrderisfulfilled; 


    public GameObject healthBarFG; 
    public GameObject healthBarBG; 
    private bool healthBarSliderFlag; 
    public GameObject requestBubble; 
    internal float leaveTime;
    private float creationTime; 
    private bool isLeaving; 
    public GameObject score3DText; 

    private Vector3 startingPosition;
    private Vector3 specificStartingPosition;  
     

    void Awake(){
       
        healthBarFG.SetActive(false); 
        requestBubble.SetActive(false); 
        healthBarBG.SetActive(false); 

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
    private GameObject bookImage; 

    void Init(){
        
        bookImage = Instantiate(availableProducts[studentNeeds], positionDummy.transform.position, Quaternion.Euler(90, 180, 0)) as GameObject;
        bookImage.name = "studentNeeds";
        bookImage.transform.localScale = new Vector3(0.18f, 0.1f, 0.13f);
        bookImage.transform.parent = requestBubble.transform;
        
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
            healthBarBG.SetActive(true);
            requestBubble.SetActive(true);
            healthBarFG.SetActive(true);

            transform.rotation = Quaternion.Euler(0, 180, 0); 

            yield break;
        }
        yield return 0;
    }
}


     Vector2 findMinInArray(float[] _array)
    {
        int lowestIndex = -1;
        float minval = 1000000.0f;
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] < minval)
            {
                minval = _array[i];
                lowestIndex = i;
            }
        }
        return (new Vector2(minval, lowestIndex));
    }

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
        */
    
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
        StartCoroutine(animate(Time.time, requestBubble, 0.75f, 0.95f));
        yield return new WaitForSeconds(0.4f);

        //animate mainObject (hide it, then destroy it)
        while (transform.position.x < 10)
        {
            transform.position = new Vector3(transform.position.x + (Time.deltaTime * studentMoveSpeed),
                                             startingPosition.y - 0.25f + (Mathf.Sin(Time.time * 10) / 8),
                                             transform.position.z);

            if (transform.position.x >= 10)
            {
                gameController.GetComponent<MainGameController>().availableSeatForStudents[mySeat] = true;
                Destroy(gameObject);
                yield break;
            }
            yield return 0;
        }
    }

    IEnumerator animate(float _time, GameObject _go, float _in, float _out)
    {
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime * 10;
            _go.transform.localScale = new Vector3(Mathf.SmoothStep(_in, _out, t),
                                                   _go.transform.localScale.y,
                                                   _go.transform.localScale.z);
            yield return 0;
        }
        float r = 0.0f;
        if (_go.transform.localScale.x >= _out)
        {
            while (r <= 1.0f)
            {
                r += Time.deltaTime * 2;
                _go.transform.localScale = new Vector3(Mathf.SmoothStep(_out, 0.01f, r),
                                                       _go.transform.localScale.y,
                                                       _go.transform.localScale.z);
                if (_go.transform.localScale.x <= 0.01f)
                    _go.SetActive(false);
                yield return 0;
            }
        }
    }

    }
