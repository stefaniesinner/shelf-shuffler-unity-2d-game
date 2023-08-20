using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager manager;

    public Text storageLbl;
    public Text scoreLbl;

    public Transform UIPanel;

    private void Awake()
    {
        manager = this;
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
        //AudioManager.instance.PlayHit();
        MainGameController.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    public void HideInitPanel()
    {
        AudioManager.instance.PlayHit();
        MainGameController.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        manager = null;
    }
}
