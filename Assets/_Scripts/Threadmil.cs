using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Threadmil : MonoBehaviour
{
    private float currentTime;
    private GameManager gameManager;
    private GameObject sellText;

    private void Awake()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 5)
        {
            currentTime = 0;
            gameManager.coins += 10;
            sellText = Instantiate(gameManager.sellTextPrefab);
            sellText.transform.position = transform.position + Vector3.up * 2 + Vector3.right;
                    
            sellText.GetComponentInChildren<TextMeshPro>().text = "$10";
        }
    }
}
