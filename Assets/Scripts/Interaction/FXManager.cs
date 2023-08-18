using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager obj;

    public GameObject pop;

    private void Update()
    {
        obj = this;
    }

    public void ShowPop(Vector3 pos)
    {
        pop.gameObject.GetComponent<PopController>().Show(pos);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
