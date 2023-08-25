using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public FXManager fxMgr;

    private void Awake()
    {
        fxMgr = this;
    }

    private void OnDestroy()
    {
        fxMgr = null;
    }
}
