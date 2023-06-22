using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BuyField : MonoBehaviour
{
    [SerializeField] private GameObject buyWindow;
    [SerializeField] private GameObject temp;
    public int price;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buyWindow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buyWindow.SetActive(false);
        }
    }

    public void Buy()
    {
        if (gameManager.coins >= price)
        {
            gameManager.coins -= price;
            Destroy(temp);
            Destroy(buyWindow);
        }
    }
    
    public void BuyWallA()
    {
        if (gameManager.coins >= price)
        {
            buyWindow.SetActive(false);
            gameManager.coins -= price;
            gameManager.haveWallA = 0;
            gameManager.newLevelSound.Play();
            gameManager.SaveAll();
            gameManager.LoadAll();
            buyWindow.SetActive(false);
        }
    }
    
    public void BuyWallB()
    {
        if (gameManager.coins >= 6399)
        {
            buyWindow.SetActive(false);
            gameManager.coins -= 6399;
            gameManager.haveWallB = 0;
            gameManager.SaveAll();
            gameManager.LoadAll();
            buyWindow.SetActive(false);
        }
    }
    
    public void BuyWallC()
    {
        if (gameManager.coins >= price)
        {
            buyWindow.SetActive(false);
            gameManager.coins -= price;
            gameManager.haveWallC = 0;
            gameManager.newLevelSound.Play();
            gameManager.SaveAll();
            gameManager.LoadAll();
            buyWindow.SetActive(false);
        }
    }

    public void NewChicken()
    {
        if (gameManager.coins >= price)
        {
            gameManager.chickenSound.Play();
            gameManager.chickens++;
            gameManager.coins -= price;
            GameObject chicken = Instantiate(gameManager.chickenPrefab); 
            chicken.transform.position = new Vector3(45.5f, 0, 38);
        }

    }
}
