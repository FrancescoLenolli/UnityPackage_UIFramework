using TMPro;
using UnityEngine;

namespace Localization
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private LocalizedString localizedString;
        private TextMeshProUGUI label;

        private void Start()
        {
            label = GetComponent<TextMeshProUGUI>();
            LocalizeText(localizedString.key);

            EventManager.StartListening("ChangedLanguage", () => { LocalizeText(localizedString.key); });
        }

        private void LocalizeText(string key)
        {
            if (key == null)
            {
                Debug.LogWarning($"No Key assigned in the LocalizedText component at" +
                    $" '{gameObject.name}'. This will cause issues with the User Interface while playing.");
                return;
            }

            var value = LocalizationManager.GetLocalizedValue(key);

            if (value == "")
            {
                Debug.LogWarning($"Key '{localizedString.key}' used at '{gameObject.name}' has no value assigned for" +
                    $" {LocalizationManager.language}. Check the Localization file for errors.");
            }

            label.text = value;
        }
    }
}