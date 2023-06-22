using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")] private static extern string GetLang();
    public string currentLanguage;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            Translator.SelectLanguage(PlayerPrefs.GetInt("Language"));
        }
        else
        {
            currentLanguage = GetLang();
            switch (currentLanguage)
            {
                //Translator translator = FindObjectOfType<Translator>();
                case "en":
                    Translator.SelectLanguage(1);
                    break;
                case "ru":
                    Translator.SelectLanguage(0);
                    break;
                case "tr":
                    Translator.SelectLanguage(2);
                    break;
                default:
                    Translator.SelectLanguage(0);
                    break;
            }
        }

    }
    
    
}