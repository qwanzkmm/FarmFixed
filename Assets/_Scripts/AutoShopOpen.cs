using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShopOpen : MonoBehaviour
{
    [SerializeField] private Dirt[] dirts;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Dirt dirt in dirts)
        {
            if (dirt.haveSeed == 1) continue;
            gameManager.buySeedWindow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.buySeedWindow.SetActive(false);
    }
}
