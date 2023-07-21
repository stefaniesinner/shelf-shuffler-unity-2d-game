using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI; 
using TMPro; 

public class MainGameController : MonoBehaviour{

    public GameObject [] students; 


    public bool[] availableSeatForStudents; 
    public Vector3[] seatPositions; 

    public GameObject endGamePlane;		
	public GameObject endGameStatus;

    private int delay; 
    private bool canCreateNewStudent; 

    static public int totalScore; 
    static public bool gameIsFinished; 

    public GameObject scoreText;


    [SerializeField]
private TMP_Text studentLetterTextPrefab;

[SerializeField]
    private healthbarScript healthBarPrefab;


    public void Awake(){
        Init(); 
    
    }

    void Init(){

        delay = 8; 
        canCreateNewStudent = false; 
        totalScore = 0; 
        gameIsFinished = false; 

        for(int i = 0; i < availableSeatForStudents.Length; i++) {
			availableSeatForStudents[i] = true;
		}
    }
    IEnumerator Start(){
        yield return new WaitForSeconds(2); 
        canCreateNewStudent = true; 

    }

    void Update(){
        if(canCreateNewStudent && !gameIsFinished){
            if(monitorAvailableSeats() !=0){
                createStudent( freeSeatIndex[Random.Range(0, freeSeatIndex.Count)] ); 

            }
        
        }
    }
    
 void createStudent(int _seatIndex)
{
    canCreateNewStudent = false;
    StartCoroutine(reactiveStudentCreation());

    GameObject prefstudent = students[Random.Range(0, students.Length)];
    Vector3 seat = seatPositions[_seatIndex];
    availableSeatForStudents[_seatIndex] = false;

    int offset = -5;
    GameObject newStudent = Instantiate(prefstudent, new Vector3(offset, -0.5f, 0.2f), Quaternion.identity) as GameObject;

    newStudent.GetComponent<StudentController>().mySeat = _seatIndex;
    newStudent.GetComponent<StudentController>().destination = seat;

    StudentController studentController = newStudent.GetComponent<StudentController>();

    // Randomly select a book GameObject 
    GameObject[] booksArray = studentController.GetBooks();
    int selectedBook = Random.Range(0, booksArray.Length);
    GameObject book = Instantiate(booksArray[selectedBook], newStudent.transform.position + Vector3.up, Quaternion.identity);
    book.transform.parent = newStudent.transform;

    // Get the section letter and book letter from the StudentController
    string[] sectionsArray = studentController.GetSections();
    string[] bookLettersArray = studentController.GetBookLetters();

    TMP_Text bookLetterText = book.GetComponentInChildren<TMP_Text>();
    if (bookLetterText != null)
    {
        string bookLetter = bookLettersArray[selectedBook];
        bookLetterText.text = bookLetter;
    }
    TMP_Text[] sectionTextPrefabs = studentController.GetSectionTextPrefabs();
TMP_Text sectionTextPrefab = sectionTextPrefabs[bookLettersArray[selectedBook][0] - 'A'];
TMP_Text sectionTextInstance = Instantiate(sectionTextPrefab, book.transform.position + Vector3.up * 1.5f, Quaternion.identity);

    if (sectionTextInstance != null)
    {
       
        string sectionLetter = sectionsArray[studentController.GetSelectedSection()];
        sectionTextInstance.text = sectionLetter;
    }

    TMP_Text studentLetterText = Instantiate(studentLetterTextPrefab, newStudent.transform.position + Vector3.up * 2.5f, Quaternion.identity);
    if (studentLetterText != null)
    {
        string studentLetter = bookLettersArray[selectedBook];
        studentLetterText.text = studentLetter;
    }

    healthbarScript healthBarInstance = Instantiate(healthBarPrefab, newStudent.transform.position + Vector3.up * 1.5f, Quaternion.identity);
healthBarInstance.transform.SetParent(newStudent.transform, worldPositionStays: false);

    newStudent.GetComponent<StudentController>().healthBar = healthBarInstance;
   
    if (book != null && healthBarInstance != null)
{
    healthBarInstance.transform.SetParent(book.transform, false);
}

}

    
    IEnumerator reactiveStudentCreation(){
        yield return new WaitForSeconds(delay); 
        canCreateNewStudent = true; 
        yield break; 
    }

    private List<int> freeSeatIndex = new List<int>(); 
    int monitorAvailableSeats(){
        freeSeatIndex = new List<int>(); 
        for(int i = 0; i < availableSeatForStudents.Length; i++) {
			if(availableSeatForStudents[i] == true)
				freeSeatIndex.Add(i);
		}
        if(freeSeatIndex.Count > 0)
			return -1;
		else
			return 0;
    }

    void manageGuiTexts (){
        scoreText.GetComponent<TextMesh>().text= "+" + totalScore.ToString(); 
    }
/*
    IEnumerator processGameFinish(){

        yield return new WaitForSeconds(1.5f); 
        print("game is finished"); 
        GameObject[] studentsInScene = GameObject.FindGameObjectsWithTag("student");
		if(studentsInScene.Length > 0) {
			foreach(var student in studentsInScene) {
				student.GetComponent<StudentController>().leave();
			}
		}
    }
    */
    
}