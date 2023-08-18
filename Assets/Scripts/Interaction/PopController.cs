using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopController : MonoBehaviour
{
    public static PopController obj;

    private void Update()
    {
        obj = this;
    }

    public void Show(Vector3 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
