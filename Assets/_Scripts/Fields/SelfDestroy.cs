using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroySelf", 1.2f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
