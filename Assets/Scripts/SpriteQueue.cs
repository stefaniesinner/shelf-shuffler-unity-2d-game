using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteQueue : MonoBehaviour
{
    public GameObject spritePrefab;
    public GameObject circlePrefab;
    public float minSpawnInterval = 2f; // Minimum time interval between each sprite spawn
    public float maxSpawnInterval = 5f; // Maximum time interval between each sprite spawn
    public int maxQueueSize = 5; // Maximum size of the queue

    public PlayerController player; // Reference to the player object

    private Queue<GameObject> spriteQueue;
    private List<GameObject> spriteList;
    private float spawnTimer; // Timer for sprite spawning
    private Vector3 initialPosition = new Vector3(-4.29f, -0.25f, 0f); // Initial position of the first sprite
    private Vector3 targetPosition = new Vector3(0.90f, -0.25f, 0f); // Target position for the first sprite
    private Vector3 newTargetPosition; 
    private float xOffset = 1f;
    private float movementSpeed = 2f; // Speed at which the sprites move towards the target position

    private bool isSpriteMoving; // Flag to check if the sprite is currently moving

    private void Start()
    {
        spriteQueue = new Queue<GameObject>();
        spriteList = new List<GameObject>();
        spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
        newTargetPosition = new Vector3(4.95f, targetPosition.y, targetPosition.z);

        SpawnFirstSprite();
    }

    private void Update()
    {
        MoveSpritesTowardsTarget();
    }

    public void SpawnFirstSprite()
    {
        GameObject firstSprite = Instantiate(spritePrefab, initialPosition, Quaternion.identity);

        StartCoroutine(MoveSprite(firstSprite, targetPosition));
        spriteQueue.Enqueue(firstSprite);
        spriteList.Add(firstSprite);

        StartCoroutine(RestartMovementAfterDelay(firstSprite));
    }

  private IEnumerator RestartMovementAfterDelay(GameObject sprite)
{
    yield return new WaitForSeconds(5f); 

    Vector3 newTargetPosition = new Vector3(4.95f, sprite.transform.position.y, sprite.transform.position.z);
    StartCoroutine(MoveSprite(sprite, newTargetPosition));
}


    public void UpdateSpritePositions()
    {
        Vector3 newPosition = targetPosition;

        for (int i = 1; i < spriteList.Count; i++)
        {
            GameObject sprite = spriteList[i];
            newPosition += new Vector3(xOffset, 0f, 0f);
            StartCoroutine(MoveSprite(sprite, newPosition - new Vector3(xOffset * 0.5f, 0f, 0f)));
        }
    }

    private void MoveSpritesTowardsTarget()
    {
        for (int i = 1; i < spriteList.Count; i++)
        {
            GameObject sprite = spriteList[i];
            Vector3 targetPosition = this.targetPosition + new Vector3(-xOffset * (i - 1), 0f, 0f);
            StartCoroutine(MoveSprite(sprite, targetPosition - new Vector3(xOffset * 0.5f, 0f, 0f)));
        }
    }

    private IEnumerator MoveSprite(GameObject sprite, Vector3 targetPosition)
    {
    if (isSpriteMoving)
        yield break;

    isSpriteMoving = true;

    Rigidbody2D spriteRigidbody = sprite.GetComponent<Rigidbody2D>();

    Vector3 startPosition = sprite.transform.position;
    float distance = Vector3.Distance(startPosition, targetPosition);
    float time = distance / movementSpeed;
    float elapsedTime = 0f;

    while (elapsedTime < time)
    {
        float t = elapsedTime / time;
        sprite.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        elapsedTime += Time.deltaTime;

        yield return null;
    }

    sprite.transform.position = targetPosition;

    if (targetPosition == this.targetPosition)
    {
        spriteRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        GameObject circleSprite = SpawnNewCircleSprite(targetPosition);
        StartCoroutine(DisappearCircleAfterDelay(circleSprite, 5f));
    }
    else if (targetPosition == newTargetPosition)
    {
        Destroy(sprite);
    }

    if (sprite == spriteList[spriteList.Count - 1])
    {
        if (spriteQueue.Count > 1)
        {
            GameObject stoppedSprite = spriteQueue.Dequeue();
            SpawnNewCircleSprite(stoppedSprite.transform.position);
        }
    }

    isSpriteMoving = false;
}


    private IEnumerator DisappearCircleAfterDelay(GameObject circleSprite, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (circleSprite != null)
            Destroy(circleSprite);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject sprite = other.gameObject;
            Rigidbody2D spriteRigidbody = sprite.GetComponent<Rigidbody2D>();

            if (!isSpriteMoving && spriteRigidbody != null && spriteRigidbody.velocity == Vector2.zero)
            {
                StartCoroutine(MoveSprite(sprite, targetPosition));
            }
        }
    }

    private GameObject SpawnNewCircleSprite(Vector3 position)
    {
        GameObject newCircleSprite = Instantiate(circlePrefab, position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        newCircleSprite.GetComponent<SpriteRenderer>().color = GetRandomColor();
        return newCircleSprite;
    }

    private Color GetRandomColor()
    {
        Color[] availableColors = { Color.blue, Color.green, new Color(0.75f, 0.4f, 1f), Color.yellow, Color.red };
        int randomIndex = Random.Range(0, availableColors.Length);
        return availableColors[randomIndex];
    }
}
