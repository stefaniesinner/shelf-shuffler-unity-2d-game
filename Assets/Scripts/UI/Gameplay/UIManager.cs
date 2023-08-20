using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;

    public Text storageLbl;
    public Text scoreLbl;

    public Transform UIPanel;

    private void Awake()
    {
        obj = this;
    }

    public void UpdateStorage()
    {
        storageLbl.text = "" + PlayerController.obj.storage;
    }

    public void UpdateScore()
    {
        scoreLbl.text = "" + MainGameController.obj.score;
    }

    public void StartGame()
    {
        //AudioManager.obj.PlayJump();

        MainGameController.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }

    public void HideInitPanel()
    {
        AudioManager.obj.PlayHit();
        MainGameController.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
