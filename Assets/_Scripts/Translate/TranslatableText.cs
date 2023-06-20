using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslatableText : MonoBehaviour
{
    public int textID;
    [HideInInspector] public TextMeshProUGUI UIText;


    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        Translator.Add(this);
    }

    private void OnEnable()
    {
        Translator.UpdateText();
    }

    private void OnDestroy()
    {
        Translator.Delete(this);
    }
}
