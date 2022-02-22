using System.Collections;
using System.Collections.Generic;
using CSVUtilities;
using UnityEngine;

namespace CSVUtilities
{
    public class LocalizationReader : CSVReader
    {
        public Dictionary<string, List<string>> localizationDictionary = new Dictionary<string, List<string>>();
        
        public override void FormatData(TextAsset textAsset, int elementCount)
        {
            CSVInfo info = ReadData(textAsset, elementCount);
            
            for (int i = 0; i < info.tableSize; i++)
            {
                // Add Key to identify what text this is.
                string key = info.data[elementCount * (i + 1)];
                localizationDictionary.Add(key, new List<string>());
                
                for (int j = 1; j < elementCount; j++)
                {
                    // Add Localized texts.
                    localizationDictionary[key].Add(info.data[elementCount * (i + 1) + j]);
                }
            }
        }
    }
}
