using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggCollect : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.collectSound.Play();
            gameManager.coins += gameManager.eggSellPrice;
            gameManager.eggsCount--;
            GameObject sellText = Instantiate(gameManager.sellTextPrefab);
            sellText.transform.position = transform.position + Vector3.up;
                    
            sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.eggSellPrice.ToString();
            Destroy(gameObject);
        }
    }
}
