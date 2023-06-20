using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private static int LanguageID;

    private static List<TranslatableText> listID = new List<TranslatableText>();

    private static string[,] lineText =
    {
        #region Russian
        {
            "Семена",
            "Шляпы",
            "Монеты",
            "Вы должны находиться на грядке чтобы посадить семена",
            "Открыть $90",
            "Открыть $170",
            "Открыть $230",
            "Открыть $700",
            "СКОРОСТЬ РОСТА X5 \n30s",
            "СТАТЬ БЫСТРЕЕ НАВСЕГДА",
            "Купить эту землю",
            "Недостаточно средств :(",
            "Открыть новую зону",
            "Недостаточно средств :(",
            "Купить курицу", //14
            "Купить эту землю",
            "Купить эту землю",
            "Недостаточно средств :(",
            "Открыть новую зону",
            "Недостаточно средств :(",
            "Открыть новую зону", //20
            "Недостаточно средств :(",
            "Купить беговую дорожку",
            "Получить $1000"
            
            
        },
        #endregion

        #region English
        {
            "Seeds", //0
            "Hats",
            "Coins", 
            "You have to be above the garden bed to buy seeds",
            "Unlock $90",
            "Unlock $170",
            "Unlock $230",
            "Unlock $700",
            "GROWTH RATE X5 \n30s",
            "BECOME FASTER FOREVER",
            "Buy this field",
            "Not enough money :(",
            "Buy new zone",
            "Not enough money :(",
            "Buy new chicken", //14
            "Buy this field",
            "Buy this field",
            "Not enough money :(",
            "Buy new zone",
            "Not enough money :(",
            "Buy new zone", //20
            "Not enough money :(",
            "Buy threadmil",
            "Get $1000"

        },
        #endregion

        #region Turkish
        {
            "Tohum",
            "Şapkalar",
            "Para",
            "Tohum almak için bahçe yatağının üstünde olmalısın",
            "Satın Al $90",
            "Satın Al $170",
            "Satın Al $230",
            "Satın Al $700",
            "BÜYÜME oranı X5 \n30s",
            "SONSUZA KADAR DAHA hızlı OL",
            "Bu alanı satın al",
            "Yeterli para yok :(",
            "Yeni bölge satın al",
            "Yeterli para yok :(",
            "Yeni tavuk al", //14
            "Bu alanı satın al",
            "Bu alanı satın al",
            "Yeterli para yok :(",
            "Buy new zone",
            "Yeterli para yok :(",
            "Yeni bölge satın al", //20
            "Yeterli para yok :(",
            "Koşu bandı satın al",
            "Almak $1000"
        }
        #endregion
    };

    static public void SelectLanguage(int id)
    {
        LanguageID = id;
        UpdateText();
    }

    static public string GetText(int textKey)
    {
        return lineText[LanguageID, textKey];
    }

    static public void Add(TranslatableText idText)
    {
        listID.Add(idText);
    }

    static public void Delete(TranslatableText idText)
    {
        listID.Remove(idText);
    }

    static public void UpdateText()
    {
        for (int i = 0; i < listID.Count; i++)
        {
            listID[i].UIText.text = lineText[LanguageID, listID[i].textID];
            //if (YandexPlayerPrefs.GetInt("Language") == 0) listID[i].UIText.font = Resources.Load<TMP_FontAsset>("RU_font_asset");
            //else if (YandexPlayerPrefs.GetInt("Language") == 2) listID[i].UIText.font = Resources.Load<TMP_FontAsset>("TR_font_asset");
            //else listID[i].UIText.font = Resources.Load<TMP_FontAsset>("EN_font_asset");
        }
    }

}