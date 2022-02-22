using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using CSVUtilities;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public enum Language
    {
        English = 0,
        Italian = 1,
        Spanish = 2
    }

    [SerializeField] private TextAsset localizationData;
    private static Dictionary<string, List<string>> localizationDictionary;
    private Language language;
    
    private void Start()
    {
        if(localizationDictionary == null)
            Init();
        
        ChangeLanguage(Language.English);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeLanguage(Language.Italian);
        }
    }

    public List<string> GetValue(string key)
    {
        if (localizationDictionary == null)
            Init();

        List<string> values = new List<string>();
        localizationDictionary.TryGetValue(key, out values);

        return values;
    }

    private void Init()
    {
        localizationDictionary = new Dictionary<string, List<string>>();
        LocalizationReader reader = new LocalizationReader();
        reader.FormatData(localizationData, Enum.GetNames(typeof(Language)).Length + 1);
        localizationDictionary = reader.localizationDictionary;
    }
    
    private void ChangeLanguage(Language newLanguage)
    {
        language = newLanguage;
        EventManager.TriggerEvent("ChangeLanguage", language);
    }
}
