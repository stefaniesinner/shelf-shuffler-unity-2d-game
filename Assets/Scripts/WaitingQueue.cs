using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour
{
    private List<Students> studentsList;
    private List<Vector3> positionList;
    private Vector3 entrancePosition;

    public void Initialize(List<Vector3> positions, List<GameObject> studentPrefabs)
    {
        positionList = positions;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-1f, 0f);

        studentsList = new List<Students>();

        for (int i = 0; i < positionList.Count; i++)
        {
            Vector3 position = positionList[i];
            GameObject prefab = studentPrefabs[i % studentPrefabs.Count];
            GameObject studentGO = Instantiate(prefab, position, Quaternion.identity);
            Students student = studentGO.GetComponent<Students>();
            studentsList.Add(student);
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

    public bool CanEnter()
    {
        return studentsList.Count > 0 && studentsList[0] == this;
    }
}
