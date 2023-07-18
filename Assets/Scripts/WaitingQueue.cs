using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour
{
    private List<Students> studentsList;
    private List<Vector3> positionList;
    private Vector3 entrancePosition;
    private float spacing = 0.5f;

    private void Awake()
    {
        studentsList = new List<Students>();
    }

    public void Initialize(List<Vector3> positionList, List<Students> studentsList)
    {
        this.positionList = positionList;
        this.studentsList = studentsList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-4f, 0);

        for (int i = 0; i < positionList.Count; i++)
        {
            Vector3 position = positionList[i] + new Vector3(i * spacing, 0f, 0f);
            GameObject square = GameObject.CreatePrimitive(PrimitiveType.Quad);
            square.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            square.transform.position = position;
            square.GetComponent<Renderer>().material.color = Color.green;
        }

        GameObject entranceSquare = GameObject.CreatePrimitive(PrimitiveType.Quad);
        entranceSquare.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        entranceSquare.transform.position = entrancePosition;
        entranceSquare.GetComponent<Renderer>().material.color = Color.blue;
    }

    public bool CanAddStudents()
    {
        return studentsList.Count < positionList.Count;
    }

    public void AddStudents(Students students)
    {
    studentsList.Add(students);
    students.MoveToOutsidePosition(() =>
    {
        students.MoveToEntrancePosition(() =>
        {
            students.MoveTo(positionList[studentsList.IndexOf(students)]);
        });
    });
    }


    public bool CanEnter(Students students)
    {
        return studentsList.Count > 0 && studentsList[0] == students;
    }

    public Vector3 GetEntrancePosition()
    {
        return entrancePosition;
    }
}
