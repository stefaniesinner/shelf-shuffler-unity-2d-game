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

            AudioManager.obj.PlayHit();

            UIManager.obj.UpdateScore();

            FXManager.obj.ShowPop(transform.position);
            gameObject.SetActive(false);
        }
    }
}
