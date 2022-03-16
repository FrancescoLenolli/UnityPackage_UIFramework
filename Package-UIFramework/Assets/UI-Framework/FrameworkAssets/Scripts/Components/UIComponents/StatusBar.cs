using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UIFramework.Components
{
    /// <summary>
    /// Base StatusBar values.
    /// </summary>
    public struct StatusInfo
    {
        public string valueName;
        public float minValue;
        public float maxValue;
        public float currentValue;
        public UnityAction<float> action;

        public StatusInfo(string valueName, float minValue, float maxValue,
            float currentValue, UnityAction<float> action = null)
        {
            this.valueName = valueName;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.currentValue = currentValue;
            this.action = action;
        }
    }

    /// <summary>
    /// Display a given stat like health, stamina, etc...
    /// </summary>
    public class StatusBar : UIComponent
    {
        [SerializeField]
        private CustomSlider slider = null;
        [SerializeField]
        private TextMeshProUGUI valueNameLabel = null;

        public void Init(StatusInfo statusValues)
        {
            valueNameLabel.text = statusValues.valueName;
            slider.Init(statusValues.minValue, statusValues.maxValue,
                statusValues.currentValue, false, statusValues.action);
        }

        public void SetValue(float value)
        {
            slider.SetValue(value);
        }

        public float GetValue()
        {
            return slider.GetValue();
        }

        public void ResetValue()
        {
            slider.ResetValue();
        }
    }
}
