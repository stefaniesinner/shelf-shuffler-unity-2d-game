using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private int scoreGive = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainGameController.obj.AddScore(scoreGive);
            PlayerController.obj.AddToInventory();

            gameObject.SetActive(false);
        }
    }
}
