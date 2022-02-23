using System.Collections.Generic;

public class LocalizationSystem
{
    public enum Language
    {
        English,
        French,
        Italian,
        Spanish
    }

    public static bool isInit;
    public static CSVLoader csvLoader;
    public static Language language = Language.French;

    private static Dictionary<string, string> localizedENG;
    private static Dictionary<string, string> localizedFR;
    private static Dictionary<string, string> localizedITA;
    private static Dictionary<string, string> localizedESP;

    public static void Init()
    {
        csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        UpdateDictionaries();

        isInit = true;
    }

    public static void Add(string key, string value)
    {
        if (value.Contains("\""))
            value.Replace('"', '\"');

        if (csvLoader == null)
            csvLoader = new CSVLoader();

        csvLoader.LoadCSV();
        csvLoader.Add(key, value);
        csvLoader.LoadCSV();

        UpdateDictionaries();
    }

    public static void Replace(string key, string value)
    {
        
        if (value.Contains("\""))
            value.Replace('"', '\"');

        if (csvLoader == null)
            csvLoader = new CSVLoader();

        csvLoader.LoadCSV();
        csvLoader.Edit(key, value);
        csvLoader.LoadCSV();

        UpdateDictionaries();
    }

    public static void Remove(string key)
    {
        if (csvLoader == null)
            csvLoader = new CSVLoader();

        csvLoader.LoadCSV();
        csvLoader.Remove(key);
        csvLoader.LoadCSV();

        UpdateDictionaries();
    }

    public static string GetLocalizedValue(string key)
    {
        if (!isInit) Init();

        var value = key;
        switch (language)
        {
            case Language.English:
                localizedENG.TryGetValue(key, out value);
                break;

            case Language.French:
                localizedFR.TryGetValue(key, out value);
                break;

            case Language.Italian:
                localizedITA.TryGetValue(key, out value);
                break;

            case Language.Spanish:
                localizedESP.TryGetValue(key, out value);
                break;
        }

        return value;
    }

    public static Dictionary<string, string> GetDictionaryForEditor()
    {
        if (!isInit) Init();
        return localizedENG;
    }

    private static void UpdateDictionaries()
    {
        localizedENG = csvLoader.GetDictionaryValues("eng");
        localizedFR = csvLoader.GetDictionaryValues("fr");
        localizedITA = csvLoader.GetDictionaryValues("ita");
        localizedESP = csvLoader.GetDictionaryValues("esp");
    }
}