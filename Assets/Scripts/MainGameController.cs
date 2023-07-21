using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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
    
    void createStudent( int _seatIndex) {

        canCreateNewStudent = false; 
        StartCoroutine(reactiveStudentCreation()); 
        
        GameObject prefstudent = students[Random.Range(0, students.Length)]; 

        Vector3 seat = seatPositions[_seatIndex]; 

        availableSeatForStudents[_seatIndex] = false; 

        int offset = -5; 
        GameObject newStudent = Instantiate(prefstudent, new Vector3(offset, -0.5f, 0.2f), Quaternion.identity) as GameObject;

        newStudent.GetComponent<StudentController>().mySeat = _seatIndex; 

        newStudent.GetComponent<StudentController>().destination = seat; 
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