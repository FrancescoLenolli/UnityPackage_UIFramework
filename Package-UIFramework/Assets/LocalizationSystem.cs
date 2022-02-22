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

    public static Language language = Language.French;
    public static bool isInit;

    private static Dictionary<string, string> localizedENG;
    private static Dictionary<string, string> localizedFR;
    private static Dictionary<string, string> localizedITA;
    private static Dictionary<string, string> localizedESP;

    public static void Init()
    {
        var csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localizedENG = csvLoader.GetDictionaryValues("eng");
        localizedFR = csvLoader.GetDictionaryValues("fr");
        localizedITA = csvLoader.GetDictionaryValues("ita");
        localizedESP = csvLoader.GetDictionaryValues("esp");

        isInit = true;
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
}