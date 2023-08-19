using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;

    public Text inventoryLbl;
    public Text scoreLbl;

    public Transform UIPanel;

    private void Update()
    {
        obj = this;
    }

    public void UpdateInventory()
    {
        inventoryLbl.text = "" + PlayerController.obj.storage;
    }

    public void UpdateScore()
    {
        scoreLbl.text = "" + MainGameController.obj.score;
    }

    public void StartGame()
    {
        AudioManager.obj.PlayJump();

        MainGameController.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }

    public void HideInitPanel()
    {
        AudioManager.obj.PlayJump();
        MainGameController.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
