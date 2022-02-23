using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private LocalizedString localizedString;
    private TextMeshProUGUI label;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        LocalizeText(localizedString.Value);
    }

    private void LocalizeText(string key)
    {
        var value = LocalizationSystem.GetLocalizedValue(key);
        label.text = value;
    }
}