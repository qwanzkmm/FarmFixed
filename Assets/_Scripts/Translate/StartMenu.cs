using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        Translator.SelectLanguage(PlayerPrefs.GetInt("Language"));
    }

    public void LanguageChange(int id)
    {
        Translator.SelectLanguage(id);
        PlayerPrefs.SetInt("Language", id);
    }
}
