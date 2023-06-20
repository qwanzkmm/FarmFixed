using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raised : MonoBehaviour
{
    public string name;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = other.GetComponent<GameManager>();
            GameObject sellText;
            gameManager.collectSound.Play();
            switch (name)
            {
                case ("carrot"):
                    gameManager.coins += gameManager.carrotSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position - Vector3.right * 4 + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.carrotSellPrice.ToString();
                    break;
                
                case ("carbage"):
                    gameManager.coins += gameManager.carbageSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position - Vector3.right * 4 + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.carbageSellPrice.ToString();
                    break;
                
                case ("potato"):
                    gameManager.coins += gameManager.potatoSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position - Vector3.right * 4 + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.potatoSellPrice.ToString();
                    break;
                
                case ("strawberry"):
                    gameManager.coins += gameManager.strawberrySellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.strawberrySellPrice.ToString();
                    break;
                
                case ("pumpkin"):
                    gameManager.coins += gameManager.pumpkinSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.pumpkinSellPrice.ToString();
                    break;
                
                case ("sunflower"):
                    gameManager.coins += gameManager.sunflowerSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.sunflowerSellPrice.ToString();
                    break;
                
                case ("corn"):
                    gameManager.coins += gameManager.cornSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position - Vector3.right * 4 + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.cornSellPrice.ToString();
                    break;
                
                case ("grape"):
                    gameManager.coins += gameManager.grapeSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.grapeSellPrice.ToString();
                    break;
                
                case ("melon"):
                    gameManager.coins += gameManager.melonSellPrice;
                    sellText = Instantiate(gameManager.sellTextPrefab);
                    sellText.transform.position = transform.position + Vector3.up;
                    
                    sellText.GetComponentInChildren<TextMeshPro>().text = "$"+gameManager.melonSellPrice.ToString();
                    break;
            }

            Destroy(gameObject);
        }
    }
    
    
    
    
}
