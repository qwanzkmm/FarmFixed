using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System.Runtime.InteropServices;


public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")] private static extern int SetToLeaderboard(int value);
    public int coins;
    

    public float raiseSpeed = 1f;
    public float runSpeed = 1f;

    [Header("Sounds")]
    public AudioSource shovelSound;
    public AudioSource collectSound;
    public AudioSource chickenSound;
    public AudioSource newLevelSound;
    public AudioSource soundtrack;

    [Header("Chickens Settings")] 
    public GameObject chickenPrefab;
    public int eggsCount;
    public int chickens;
    public int maxEggsCount;
    public float timeToCreateEgg;
    public Transform[] pointsChickens;
    public GameObject eggPrefab;

    [Header("Sell Prices")] 
    public int eggSellPrice = 30;
    public int carrotSellPrice = 50;
    public int carbageSellPrice = 90;
    public int potatoSellPrice = 105;
    public int strawberrySellPrice = 155;
    public int pumpkinSellPrice = 160;
    public int sunflowerSellPrice = 230;
    public int cornSellPrice = 350;
    public int grapeSellPrice = 350;
    public int melonSellPrice = 500;
    
    
    [Header("Seed Time")] 
    public float carrotTime = 12f;
    public float carbageTime = 18f;
    public float potatoTime = 22f;
    public float strawberryTime = 40f;
    public float pumpkinTime = 36f;
    public float sunflowerTime = 64f;
    public float cornTime = 90f;
    public float grapeTime = 95f;
    public float melonTime = 120f;


    [Header("Seed Prefabs")] 
    
    public GameObject sellTextPrefab;
    
    public GameObject carrotRaised;
    public GameObject carrotSeed;
    
    public GameObject carbageRaised;
    public GameObject carbageSeed;
    
    public GameObject potatoRaised;
    public GameObject potatoSeed;
    
    public GameObject strawberryRaised;
    public GameObject strawberrySeed;
    
    public GameObject pumpkinRaised;
    public GameObject pumpkinSeed;
    
    public GameObject sunflowerRaised;
    public GameObject sunflowerSeed;
    
    public GameObject cornRaised;
    public GameObject cornSeed;
    
    public GameObject grapeRaised;
    public GameObject grapeSeed;
    
    public GameObject melonRaised;
    public GameObject melonSeed;
    
    
    public LayerMask dirtLayer;
    
    [Header("UI")]
    public GameObject buySeedWindow;
    public GameObject buySeedWindowReady;
    public GameObject dirtErrorText;
    public TextMeshProUGUI coinsText;

    [Header("Zones and Buildings")] 
    public GameObject WallA;
    public GameObject WallB;
    public GameObject WallC;

    public GameObject FieldAT;
    public GameObject FieldBT;
    public GameObject FieldCT;
    
    public GameObject ChickenFarm;
    public GameObject ThreadmilR;
    public GameObject ThreadmilT;

    public int haveWallA;
    public int haveWallB;
    public int haveWallC;
    
    public int haveFieldA;
    public int haveFieldB;
    public int haveFieldC;
    
    public int haveChickenFarm;
    public int haveThreadmil;

    [Header("Seeds")] 
    public int havePotato;
    public int haveStrawberry;
    public int havePumpkin;
    public int haveSunflower;
    public int haveCorn;
    public int haveGrape;
    public int haveMelon;

    public GameObject potatoT;
    public GameObject strawberryT;
    public GameObject pumpkinT;
    public GameObject sunflowerT;
    public GameObject cornT;
    public GameObject grapeT;
    public GameObject melonT;
    
    public GameObject potatoR;
    public GameObject strawberryR;
    public GameObject pumpkinR;
    public GameObject sunflowerR;
    public GameObject cornR;
    public GameObject grapeR;
    public GameObject melonR;
    
    
    [Header("Hats GO's")]
    public GameObject baseballHat;
    public GameObject santaHat;
    public GameObject witchHat;
    public GameObject captainHat;
    public GameObject cowboyHat;
    public GameObject graduationHat;
    public GameObject ufoHat;
    public GameObject sunglassesHat;
    public GameObject crownHat;
    
    public GameObject baseballHatT;
    public GameObject santaHatT;
    public GameObject witchHatT;
    public GameObject captainHatT;
    public GameObject cowboyHatT;
    public GameObject graduationHatT;
    public GameObject ufoHatT;
    public GameObject sunglassesHatT;
    public GameObject crownHatT;
    
    public int haveBaseballHat;
    public int haveSantaHat;
    public int haveWitchHat;
    public int haveCaptainHat;
    public int haveCowboyHat;
    public int haveGraduationHat;
    public int haveUFOHat;
    public int haveSunglassesHat;
    public int haveCrownHat;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("coins"))
        {
            SaveAll();
        }
        else
        {
            LoadAll();
        }
    }

    private void Update()
    {
        coinsText.text = "$" + coins.ToString();
    }

    public void GetCoins(int count)
    {
        //YaSDK.instance.ShowRewarded("coins");
        coins += count;
    }
    
    public void Seed(string name)
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, dirtLayer))
        {
            dirtErrorText.SetActive(false);
            Dirt dirt = hit.transform.GetComponent<Dirt>();
            if (dirt.haveSeed == 0)
            {
                switch (name)
                {
                    case "carrot":
                        if (coins >= 35)
                        {
                            coins -= 35;
                            dirt.Seed(name);
                        }
                        break;
                    
                    case "carbage":
                        if (coins >= 60)
                        {
                            coins -= 60;
                            dirt.Seed(name);
                        }
                        break;
                    
                    case "potato":
                        if (havePotato == 0)
                        {
                            if (coins >= 90)
                            {
                                coins -= 90;
                                havePotato = 1;
                                SaveAll();
                                LoadAll();
                            }
                        }
                        else
                        {
                            if (coins >= 70)
                            {
                                coins -= 70;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    case "strawberry":
                        if (haveStrawberry == 0)
                        {
                            YandexSDK.YaSDK.instance.ShowRewarded("seed");
                            haveStrawberry = 1;
                            SaveAll();
                            LoadAll();
                        }
                        else
                        {
                            if (coins >= 105)
                            {
                                coins -= 105;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    case "pumpkin":
                        if (havePumpkin == 0)
                        {
                            if (coins >= 170)
                            {
                                coins -= 170;
                                havePumpkin = 1;
                                SaveAll();
                                LoadAll();
                            }
                        }
                        else
                        {
                            if (coins >= 120)
                            {
                                coins -= 120;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    case "sunflower":
                        if (haveSunflower == 0)
                        {
                            if (coins >= 230)
                            {
                                coins -= 230;
                                haveSunflower = 1;
                                SaveAll();
                                LoadAll();
                            }
                        }
                        else
                        {
                            if (coins >= 150)
                            {
                                coins -= 150;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    case "corn":
                        if (haveCorn == 0)
                        {
                            YandexSDK.YaSDK.instance.ShowRewarded("seed");
                            haveCorn = 1;
                            SaveAll();
                            LoadAll();
                        }
                        else
                        {
                            if (coins >= 200)
                            {
                                coins -= 200;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    case "grape":
                        if (haveGrape == 0)
                        {
                            YandexSDK.YaSDK.instance.ShowRewarded("seed");
                            haveGrape = 1;
                            SaveAll();
                            LoadAll();
                        }
                        else
                        {
                            if (coins >= 200)
                            {
                                coins -= 200;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    case "melon":
                        if (haveMelon == 0)
                        {
                            if (coins >= 700)
                            {
                                coins -= 700;
                                haveMelon = 1;
                                SaveAll();
                                LoadAll();
                            }
                        }
                        else
                        {
                            if (coins >= 240)
                            {
                                coins -= 240;
                                dirt.Seed(name);
                            }
                        }
                        break;
                    
                    
                }
            }
        }
        else
        {
            dirtErrorText.SetActive(true);
        }
    }
    public void BuyHatAds(string name)
    {
        switch (name)
        { 
            case "captain":
                if (haveCaptainHat == 0)
                {
                    YandexSDK.YaSDK.instance.ShowRewarded("hat");
                    haveCaptainHat = 1;
                    TurnOffAllHats();
                    captainHat.SetActive(true);
                    SaveAll();
                    LoadAll();
                }
                else
                {
                    TurnOffAllHats();
                    captainHat.SetActive(true);
                }

                break;
            
            case "cowboy":
                if (haveCowboyHat == 0)
                {
                    YandexSDK.YaSDK.instance.ShowRewarded("hat");
                    haveCowboyHat = 1;
                    TurnOffAllHats();
                    cowboyHat.SetActive(true);
                    SaveAll();
                    LoadAll();
                }
                else
                {
                    TurnOffAllHats();
                    cowboyHat.SetActive(true);
                }

                break;
            
            case "graduation":
                if (haveGraduationHat == 0)
                {
                    YandexSDK.YaSDK.instance.ShowRewarded("hat");
                    haveGraduationHat = 1;
                    TurnOffAllHats();
                    graduationHat.SetActive(true);
                    SaveAll();
                    LoadAll();
                }
                else
                {
                    TurnOffAllHats();
                    graduationHat.SetActive(true); ;
                }

                break;
            
            case "sunglasses":
                if (haveSunglassesHat == 0)
                {
                    YandexSDK.YaSDK.instance.ShowRewarded("hat");
                    haveSunglassesHat = 1;
                    TurnOffAllHats();
                    sunglassesHat.SetActive(true);
                    SaveAll();
                    LoadAll();
                }
                else
                {
                    TurnOffAllHats();
                    sunglassesHat.SetActive(true);
                }
                break;
            
        }
        
    }

    public void BuyHatCoin(string names)
    {
        switch (names)
            {
                case "baseball":
                    if (haveBaseballHat == 0)
                    {
                        if (coins >= 350)
                        {
                            coins -= 350;
                            haveBaseballHat = 1;
                            TurnOffAllHats();
                            baseballHat.SetActive(true);
                            SaveAll();
                            LoadAll();
                        }
                    }
                    else
                    {
                        TurnOffAllHats();
                        baseballHat.SetActive(true);
                    }

                    break;
                case "santa":
                    if (haveSantaHat == 0)
                    {
                        if (coins >= 400)
                        {
                            coins -= 400;
                            haveSantaHat = 1;
                            TurnOffAllHats();
                            santaHat.SetActive(true);
                            SaveAll();
                            LoadAll();
                        }
                    }
                    else
                    {
                        TurnOffAllHats();
                        santaHat.SetActive(true);
                    }
                        break;
                    
                case "witch":
                    if (haveWitchHat == 0)
                    {
                        if (coins >= 980)
                        {
                            coins -= 980;
                            haveWitchHat = 1;
                            TurnOffAllHats();
                            witchHat.SetActive(true);
                            SaveAll();
                            LoadAll();
                        }
                    }
                    else
                    {
                        TurnOffAllHats();
                        witchHat.SetActive(true);
                    }
                    break;
                    
                case "ufo":
                    if (haveUFOHat == 0)
                    {
                        if (coins >= 2500)
                        {
                            coins -= 2500;
                            haveUFOHat = 1;
                            TurnOffAllHats();
                            ufoHat.SetActive(true);
                            SaveAll();
                            LoadAll();
                        }
                    }
                    else
                    {
                        TurnOffAllHats();
                        ufoHat.SetActive(true);
                    }

                    break;
                    
                case "crown":
                    if (haveCrownHat == 0)
                    {
                        if (coins >= 7777)
                        {
                            coins -= 7777;
                            haveCrownHat = 1;
                            TurnOffAllHats();
                            crownHat.SetActive(true);
                            SaveAll();
                            LoadAll();
                        }
                    }
                    else
                    {
                        TurnOffAllHats();
                        crownHat.SetActive(true);
                    }
                    break;
                    
            }
    }

    public void TurnOffAllHats()
    {
        baseballHat.SetActive(false);
        santaHat.SetActive(false);
        witchHat.SetActive(false);
        captainHat.SetActive(false);
        cowboyHat.SetActive(false);
        graduationHat.SetActive(false);
        ufoHat.SetActive(false);
        sunglassesHat.SetActive(false);
        crownHat.SetActive(false);
    }

    public void BuyFieldA()
    {
        YandexSDK.YaSDK.instance.ShowRewarded("fieldA");
        haveFieldA = 1;
        
        SaveAll();
        LoadAll();
    }
    
    public void BuyFieldB()
    {
        YandexSDK.YaSDK.instance.ShowRewarded("fieldB");
        haveFieldB = 1;
        
        SaveAll();
        LoadAll();
    }
    
    public void BuyFieldC()
    {
        if (coins >= 500)
        {
            haveFieldC = 1;
            coins -= 500;
            SaveAll();
            LoadAll();
        }
    }

    public void BuyThreadmil()
    {
        if (coins >= 799)
        {
            haveThreadmil = 1;
            coins -= 799;
            SaveAll();
            LoadAll();
        }
    }


    public void SaveAll()
    {
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetFloat("runSpeed", runSpeed);
        
        
        
        //Player
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
        
        //Zones
        PlayerPrefs.SetInt("haveWallA", haveWallA);
        PlayerPrefs.SetInt("haveWallB", haveWallB);
        PlayerPrefs.SetInt("haveWallC", haveWallC);
        PlayerPrefs.SetInt("haveFieldA", haveFieldA);
        PlayerPrefs.SetInt("haveFieldB", haveFieldB);
        PlayerPrefs.SetInt("haveFieldC", haveFieldC);
        PlayerPrefs.SetInt("haveThreadmil", haveThreadmil);
        
        
        //Hats
        PlayerPrefs.SetInt("haveBaseballHat", haveBaseballHat);
        PlayerPrefs.SetInt("haveSantaHat", haveSantaHat);
        PlayerPrefs.SetInt("haveWitchHat", haveWitchHat);
        PlayerPrefs.SetInt("haveCaptainHat", haveCaptainHat);
        PlayerPrefs.SetInt("haveCowboyHat", haveCowboyHat);
        PlayerPrefs.SetInt("haveGraduationHat", haveGraduationHat);
        PlayerPrefs.SetInt("haveUFOHat", haveUFOHat);
        PlayerPrefs.SetInt("haveSunglassesHat", haveSunglassesHat);
        PlayerPrefs.SetInt("haveCrownHat", haveCrownHat);
        
        //Seeds
        PlayerPrefs.SetInt("havePotato", havePotato);
        PlayerPrefs.SetInt("haveStrawberry", haveStrawberry);
        PlayerPrefs.SetInt("havePumpkin", havePumpkin);
        PlayerPrefs.SetInt("haveSunflower", haveSunflower);
        PlayerPrefs.SetInt("haveCorn", haveCorn);
        PlayerPrefs.SetInt("haveGrape", haveGrape);
        PlayerPrefs.SetInt("haveMelon", haveMelon);
        
        //Chickens
        PlayerPrefs.SetInt("chickens", chickens);
        
        ToLeader();
    }

    private void ToLeader()
    {
        SetToLeaderboard(coins);    
    }
    


    public void LoadAll()
    {
        coins = PlayerPrefs.GetInt("coins");
        runSpeed = PlayerPrefs.GetFloat("runSpeed");

        transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"),
            PlayerPrefs.GetFloat("PosZ"));

        haveBaseballHat = PlayerPrefs.GetInt("haveBaseballHat");
        haveSantaHat = PlayerPrefs.GetInt("haveSantaHat");
        haveWitchHat = PlayerPrefs.GetInt("haveWitchHat");
        haveCaptainHat = PlayerPrefs.GetInt("haveCaptainHat");
        haveCowboyHat = PlayerPrefs.GetInt("haveCowboyHat");
        haveGraduationHat = PlayerPrefs.GetInt("haveGraduationHat");
        haveUFOHat = PlayerPrefs.GetInt("haveUFOHat");
        haveSunglassesHat = PlayerPrefs.GetInt("haveSunglassesHat");
        haveCrownHat = PlayerPrefs.GetInt("haveCrownHat");

        //Hats
        baseballHatT.SetActive(haveBaseballHat == 0);
        santaHatT.SetActive(haveSantaHat == 0);
        witchHatT.SetActive(haveWitchHat == 0);
        captainHatT.SetActive(haveCaptainHat == 0);
        cowboyHatT.SetActive(haveCowboyHat == 0);
        graduationHatT.SetActive(haveGraduationHat == 0);
        ufoHatT.SetActive(haveUFOHat == 0);
        sunglassesHatT.SetActive(haveSunglassesHat == 0);
        crownHatT.SetActive(haveCrownHat == 0);

        //Seeds
        havePotato = PlayerPrefs.GetInt("havePotato");
        haveStrawberry = PlayerPrefs.GetInt("haveStrawberry");
        havePumpkin = PlayerPrefs.GetInt("havePumpkin");
        haveSunflower = PlayerPrefs.GetInt("haveSunflower");
        haveCorn = PlayerPrefs.GetInt("haveCorn");
        haveGrape = PlayerPrefs.GetInt("haveGrape");
        haveMelon = PlayerPrefs.GetInt("haveMelon");
        
        potatoR.SetActive(havePotato == 1);
        potatoT.SetActive(havePotato == 0);
        
        strawberryR.SetActive(haveStrawberry == 1);
        strawberryT.SetActive(haveStrawberry == 0);

        pumpkinR.SetActive(havePumpkin == 1);
        pumpkinT.SetActive(havePumpkin == 0);
        
        sunflowerR.SetActive(haveSunflower == 1);
        sunflowerT.SetActive(haveSunflower == 0);
        
        cornR.SetActive(haveCorn == 1);
        cornT.SetActive(haveCorn == 0);
        
        grapeR.SetActive(haveGrape == 1);
        grapeT.SetActive(haveGrape == 0);
        
        melonR.SetActive(haveMelon == 1);
        melonT.SetActive(haveMelon == 0);

        haveThreadmil = PlayerPrefs.GetInt("haveThreadmil");
        ThreadmilR.SetActive(haveThreadmil == 1);
        ThreadmilT.SetActive(haveThreadmil == 0);
        
        
        //Chickens
        if (chickens == 0)
        {
            chickens = PlayerPrefs.GetInt("chickens");
            for (int i = 0; i < chickens; i++)
            {
                GameObject currentChicken = Instantiate(chickenPrefab);
                currentChicken.transform.position = pointsChickens[0].transform.position;
            }
        }

        haveFieldA = PlayerPrefs.GetInt("haveFieldA");
        FieldAT.SetActive(haveFieldA == 0);
        
        haveFieldB = PlayerPrefs.GetInt("haveFieldB");
        FieldBT.SetActive(haveFieldB == 0);
        
        haveFieldC = PlayerPrefs.GetInt("haveFieldC");
        FieldCT.SetActive(haveFieldC == 0);
        
        
        haveWallA = PlayerPrefs.GetInt("haveWallA");
        WallA.SetActive(haveWallA == 1);
        
        haveWallB = PlayerPrefs.GetInt("haveWallB");
        WallB.SetActive(haveWallB == 1);
        
        haveWallC = PlayerPrefs.GetInt("haveWallC");
        WallC.SetActive(haveWallC == 1);
    }

    public void BoostRunSpeed()
    {
        YandexSDK.YaSDK.instance.ShowRewarded("speedBoost");
        runSpeed += 0.5f;
    }
    
    public void BoostGrowthSpeed()
    {
        YandexSDK.YaSDK.instance.ShowRewarded("growthBoost");
        raiseSpeed = 5f;
        Invoke("ReturnGrowthSpeed", 30f);
    }

    public void ReturnGrowthSpeed()
    {
        raiseSpeed = 1f;
    }
    
    private void OnApplicationQuit()
    {
        SaveAll();
    }

    private void OnApplicationLostFocus()
    {
        SaveAll();
    }
}
