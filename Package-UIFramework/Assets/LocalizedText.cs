using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string key = "";
    private TextMeshProUGUI label;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        LocalizeText(key);
    }

    private void LocalizeText(string key)
    {
        var value = LocalizationSystem.GetLocalizedValue(key);
        label.text = value;
    }
}