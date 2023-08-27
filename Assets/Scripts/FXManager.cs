using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>FXManager</c> handles the effects and particles.
/// </summary>
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
