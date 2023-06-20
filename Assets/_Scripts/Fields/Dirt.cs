using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    private GameManager gameManager;
    public int index;
    
    public float seedTime;
    public float currentSeedTime;

    public GameObject raisedObject;
    public GameObject seedObject;

    public string currentPlantString;
    public int haveSeed;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        if (!PlayerPrefs.HasKey("Dirt" + index.ToString() + "_Plant"))
        {
            SaveDirtInfo();
        }
        else
        {
            LoadDirtInfo();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.buySeedWindowReady.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.buySeedWindowReady.SetActive(false);
        }
    }

    private void Update()
    {
        if (haveSeed == 1)
        {
            currentSeedTime += Time.deltaTime * gameManager.raiseSpeed;
        
            if (currentSeedTime >= seedTime)
            {
                Destroy(seedObject);
                GameObject raisedObjectPR = Instantiate(raisedObject);
                if(currentPlantString == "carrot" || currentPlantString == "carbage" || currentPlantString == "potato")
                {
                    raisedObjectPR.transform.position = transform.position + Vector3.right * 4;
                }
                else if(currentPlantString == "corn")
                {
                    raisedObjectPR.transform.position = transform.position - Vector3.right * 0.5f - 0.5f * Vector3.forward + Vector3.up;
                }
                else if(currentPlantString == "pumpkin")
                {
                    raisedObjectPR.transform.position = transform.position + Vector3.up * 0.3f;
                }
                else if(currentPlantString == "strawberry")
                {
                    raisedObjectPR.transform.position = transform.position + Vector3.right * 0.4f - Vector3.forward * 0.5f + Vector3.up * 0.3f;
                }
                else if(currentPlantString == "grape")
                {
                    raisedObjectPR.transform.position = transform.position - Vector3.right * 0.4f - Vector3.forward * 0.6f + Vector3.up * 0.3f;
                }
                else if(currentPlantString == "sunflower")
                {
                    raisedObjectPR.transform.position = transform.position +Vector3.right * 0.15f - Vector3.forward * 0.2f + Vector3.up * 0.5f;
                }
                else if (currentPlantString == "melon")
                {
                    raisedObjectPR.transform.position = transform.position - Vector3.right * 0.4f - Vector3.forward - Vector3.up * 0.5f;
                }



                currentSeedTime = 0f;
                
                haveSeed = 0;
            }

        }
    }

    public void Seed(string name)
    {
        haveSeed = 1;
        gameManager.shovelSound.Play();
        switch (name)
        {
            case "carrot":
                currentPlantString = "carrot";
                raisedObject = gameManager.carrotRaised;
                seedObject = Instantiate(gameManager.carrotSeed);
                seedObject.transform.position = transform.position + Vector3.right * 2;
                seedTime = gameManager.carrotTime;
                break;
            
            case "carbage":
                currentPlantString = "carbage";
                raisedObject = gameManager.carbageRaised;
                seedObject = Instantiate(gameManager.carbageSeed);
                seedObject.transform.position = transform.position + Vector3.right * 2;
                seedTime = gameManager.carbageTime;
                break;
            
            case "potato":
                currentPlantString = "potato";
                raisedObject = gameManager.potatoRaised;
                seedObject = Instantiate(gameManager.potatoSeed);
                seedObject.transform.position = transform.position + Vector3.right * 2;
                seedTime = gameManager.potatoTime;
                break;
            
            case "strawberry":
                currentPlantString = "strawberry";
                raisedObject = gameManager.strawberryRaised;
                seedObject = Instantiate(gameManager.strawberrySeed);
                seedObject.transform.position = transform.position + Vector3.right * 0.4f - Vector3.forward * 0.5f + Vector3.up * 0.3f;
                seedTime = gameManager.strawberryTime;
                break;
            
            case "pumpkin":
                currentPlantString = "pumpkin";
                raisedObject = gameManager.pumpkinRaised;
                seedObject = Instantiate(gameManager.pumpkinSeed);
                seedObject.transform.position = transform.position + Vector3.up * 0.3f;
                seedTime = gameManager.pumpkinTime;
                break;
            
            case "sunflower":
                currentPlantString = "sunflower";
                raisedObject = gameManager.sunflowerRaised;
                seedObject = Instantiate(gameManager.sunflowerSeed);
                seedObject.transform.position = transform.position - Vector3.right * 0.2f - Vector3.forward * 0.2f + Vector3.up * 0.1f;
                seedTime = gameManager.sunflowerTime;
                break;
            
            case "corn":
                currentPlantString = "corn";
                raisedObject = gameManager.cornRaised;
                seedObject = Instantiate(gameManager.cornSeed);
                seedObject.transform.position = transform.position - Vector3.right * 0.5f - Vector3.forward * 0.3f + Vector3.up * 1f;
                seedTime = gameManager.cornTime;
                break;
            
            case "grape":
                currentPlantString = "grape";
                raisedObject = gameManager.grapeRaised;
                seedObject = Instantiate(gameManager.grapeSeed);
                seedObject.transform.position = transform.position - Vector3.right * 0.4f - Vector3.forward * 0.6f + Vector3.up * 0.3f;
                seedTime = gameManager.grapeTime;
                break;
            
            case "melon":
                currentPlantString = "melon";
                raisedObject = gameManager.melonRaised;
                seedObject = Instantiate(gameManager.melonSeed);
                seedObject.transform.position = transform.position - Vector3.right * 0.4f - Vector3.forward * 1.2f - Vector3.up * 0.5f;
                seedTime = gameManager.melonTime;
                break;
            
            default:
                print("get default state");
                break;
        }
    }

    public void SaveDirtInfo()
    {
        PlayerPrefs.SetString("Dirt"+index+"_Plant", currentPlantString);
        PlayerPrefs.SetFloat("Dirt"+index+"_Time", currentSeedTime);
        PlayerPrefs.SetInt("Dirt"+index+"_HaveSeed", haveSeed);
    }

    public void LoadDirtInfo()
    {
        currentPlantString = PlayerPrefs.GetString("Dirt" + index + "_Plant");
        currentSeedTime = PlayerPrefs.GetFloat("Dirt" + index + "_Time");
        haveSeed = PlayerPrefs.GetInt("Dirt"+index+"_HaveSeed");
        
        if(haveSeed == 1) Seed(currentPlantString);
    }


    public void OnApplicationQuit()
    {
        SaveDirtInfo();
    }

    public void OnApplicationLostFocus()
    {
        SaveDirtInfo();
    }
}
