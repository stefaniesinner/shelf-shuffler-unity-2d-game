using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Students : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public healthbarScript healthBar;
    private float timeElapsed;
    private bool isDecreasing;

    private Vector3 startingPosition;
    private Vector3 outsidePosition;

    // Reference to the WaitingQueue script
    private WaitingQueue waitingQueue;

    private bool isWalkingToEntrance = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        timeElapsed = 0f;
        isDecreasing = false;

        startingPosition = transform.position;
        outsidePosition = new Vector3(-10f, startingPosition.y, startingPosition.z);
        transform.position = outsidePosition;

        // Find the WaitingQueue script in the scene
        waitingQueue = FindObjectOfType<WaitingQueue>();
    }

    void Update()
    {
        if (timeElapsed >= 4f && !isDecreasing) //decreasing the health bar after 4 seconds
        {
            StartCoroutine(DecreaseHealthOverTime());
            isDecreasing = true;
        }

        timeElapsed += Time.deltaTime;

        // Check if the student needs to move to the entrance position
        if (isWalkingToEntrance && waitingQueue.CanEnter())
        {
            isWalkingToEntrance = false;
            MoveToEntrancePosition();
        }
    }

    IEnumerator DecreaseHealthOverTime()
    {
        for (int i = 0; i < 10; i++) // decrease the health every 2 seconds for 10 seconds
        {
            yield return new WaitForSeconds(2f);
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void MoveTo(Vector3 targetPosition, System.Action callback = null)
    {
        StartCoroutine(MoveToCoroutine(targetPosition, callback));
    }

    IEnumerator MoveToCoroutine(Vector3 targetPosition, System.Action callback)
    {
        float speed = 2.0f;
        float distance = Vector3.Distance(transform.position, targetPosition);
        float duration = distance / speed;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        callback?.Invoke();
    }

    public void MoveToEntrancePosition(System.Action callback = null)
    {
        if (waitingQueue.CanEnter())
        {
            MoveTo(startingPosition, callback);
        }
        else
        {
            isWalkingToEntrance = true;
        }
    }

    public void MoveToOutsidePosition(System.Action callback = null)
    {
        MoveTo(outsidePosition, callback);
    }
}
