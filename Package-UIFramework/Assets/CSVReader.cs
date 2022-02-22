using System;
using UnityEngine;

namespace CSVUtilities
{
    public struct CSVInfo
    {
        public string[] data;
        public int tableSize;

        public CSVInfo(string[] data, int tableSize)
        {
            this.data = data;
            this.tableSize = tableSize;
        }
    }

    public abstract class CSVReader
    {
        public CSVInfo ReadData(TextAsset textAsset, int elementCount)
        {
            var data = textAsset.text.Split(new[] {",", "\n"}, StringSplitOptions.None);
            var tableSize = data.Length / elementCount - 1;

            return new CSVInfo(data, tableSize);
        }

        public abstract void FormatData(TextAsset textAsset, int elementCount);
    }
}