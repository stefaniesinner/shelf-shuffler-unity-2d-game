using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public List<GameObject> studentPrefabs;

    private void Start()
    {
        List<Vector3> waitingQueuePositionList = new List<Vector3>();
        Vector3 firstPosition = new Vector3(2f, -0.91f);
        float positionSize = 1f;

        for (int i = 0; i < 5; i++)
        {
            waitingQueuePositionList.Add(firstPosition + new Vector3(-1f, 0f) * positionSize * i);
        }

        WaitingQueue waitingQueue = GetComponent<WaitingQueue>();
        waitingQueue.Initialize(waitingQueuePositionList, studentPrefabs);
    }
}
