﻿
    [System.Serializable]
    public struct LocalizedString
    {
        public string key;

        public LocalizedString(string key)
        {
            this.key = key;
        }
        
        public string Value
        {
            get { return LocalizationSystem.GetLocalizedValue(key); }
        }

        public static implicit operator LocalizedString(string key)
        {
            return new LocalizedString();
        }
    }