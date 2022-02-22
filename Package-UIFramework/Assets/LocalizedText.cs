using System;
using System.Collections;
using System.Collections.Generic;
using CSVUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string key = "";
    private TextMeshProUGUI label;
    private List<string> localizedTexts = new List<string>();

    private void Awake()
    {
        label = GetComponent<TextMeshProUGUI>();
        localizedTexts = FindObjectOfType<LocalizationManager>().GetValue(key);
        EventManager.StartListening("ChangeLanguage", ChangeLanguage);
    }

    private void ChangeLanguage(object value)
    {
        LocalizationManager.Language newLanguage = (LocalizationManager.Language) value;
        int index = (int) newLanguage;
        label.text = localizedTexts[index];
    }
}
