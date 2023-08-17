using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController obj;

    private bool gamePaused = false;
    private int score = 0;

    // Start is called before the first frame update
    private void Start()
    {
        obj = this;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
