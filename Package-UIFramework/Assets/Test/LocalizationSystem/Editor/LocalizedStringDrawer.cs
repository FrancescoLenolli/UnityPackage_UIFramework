using UnityEditor;
using UnityEngine;

namespace Localization
{
    [CustomPropertyDrawer(typeof(LocalizedString))]
    public class LocalizedStringDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            label.tooltip = "Assign a Key to a GameObject with a TextMeshProUGUI component attached" +
                " to display its content at runtime.";
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            position.width -= 34;
            position.height = 18;

            Rect valueRect = new Rect(position);
            valueRect.x += 15;
            valueRect.width -= 15;

            Rect foldButtonRect = new Rect(position);
            foldButtonRect.width = 15;

            position.x += 15;
            position.width -= 15;

            SerializedProperty key = property.FindPropertyRelative("key");
            key.stringValue = EditorGUI.TextField(position, key.stringValue);

            position.x += position.width + 2;
            position.width = 17;
            position.height = 17;

            GUIContent searchContent = new GUIContent((Texture)Resources.Load("editor_icon_search"), "Search for a specific Key.");
            if (GUI.Button(position, searchContent))
            {
                LocalizedTextSearchWindow.Open();
            }

            position.x += position.width + 2;

            GUIContent storeContent = new GUIContent((Texture)Resources.Load("editor_icon_add"), "Open a window where you can add new Keys to the Localization file.");
            if (GUI.Button(position, storeContent))
            {
                LocalizedTextEditorWindow.Open(key.stringValue);
            }

            EditorGUI.EndProperty();
        }
    }
}
