using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationAssist : MonoBehaviour
{
    Text text;

    public string rusLang;
    public string enLang;

    private void Awake()
    {
        text = GetComponent<Text>();
        if (Application.systemLanguage == SystemLanguage.Russian)
            text.text = rusLang;
        else
            text.text = enLang;
    }
}
