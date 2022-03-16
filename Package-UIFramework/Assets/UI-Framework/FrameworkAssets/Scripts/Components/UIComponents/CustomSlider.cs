using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIFramework.Components
{
    public class CustomSlider : UIComponent
    {
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public void Init(float minValue, float maxValue, float startingValue,
            bool wholeNumbers = false, UnityAction<float> action = null)
        {
            if(!slider)
            slider = GetComponent<Slider>();

            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.value = startingValue;
            slider.wholeNumbers = wholeNumbers;

            if (action != null)
                SetAction(action);
        }

        public void SetAction(UnityAction<float> action)
        {
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(action);
        }

        public void SetValue(float value)
        {
            slider.value = value;
        }

        public float GetValue()
        {
            return slider.value;
        }

        public void ResetValue()
        {
            slider.value = slider.maxValue;
        }

        public void EnableSlider(bool isInteractable)
        {
            slider.interactable = isInteractable;
        }
    }
}