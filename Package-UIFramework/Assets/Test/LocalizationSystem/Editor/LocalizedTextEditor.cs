using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Localization
{
    public class LocalizedTextEditorWindow : EditorWindow
    {
        public string key;
        public string value;

        public static void Open(string key)
        {
            LocalizedTextEditorWindow window = CreateInstance<LocalizedTextEditorWindow>();
            window.titleContent = new GUIContent("Localiser Window");
            window.ShowUtility();
            window.key = key;
        }

        public void OnGUI()
        {
            key = EditorGUILayout.TextField("Key :", key);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Value:", GUILayout.MaxWidth(50));

            EditorStyles.textArea.wordWrap = true;
            value = EditorGUILayout.TextArea(value, EditorStyles.textArea, GUILayout.Height(100), GUILayout.Width(400));

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Add"))
            {
                if (LocalizationManager.GetLocalizedValue(key) != string.Empty)
                    Debug.LogWarning($"The Key '{key}' you're trying to add already exists, please choose another name.");
                else
                    LocalizationManager.Add(key, value);
            }

            minSize = new Vector2(460, 250);
            maxSize = minSize;
        }
    }

    public class LocalizedTextSearchWindow : EditorWindow
    {
        public static void Open()
        {
            LocalizedTextSearchWindow window = CreateInstance<LocalizedTextSearchWindow>();
            window.titleContent = new GUIContent("Localization Search");

            Vector2 mouse = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            Rect rect = new Rect(mouse.x - 450, mouse.y + 10, 10, 10);
            window.ShowAsDropDown(rect, new Vector2(500, 300));
        }

        public string value;
        public Vector2 scroll;
        public Dictionary<string, string> dictionary;

        private void OnEnable()
        {
            dictionary = LocalizationManager.GetDictionaryForEditor();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal("Box");

            EditorGUILayout.LabelField("Search: ", EditorStyles.boldLabel);
            value = EditorGUILayout.TextField(value);

            EditorGUILayout.EndHorizontal();

            GetSearchResults();
        }

        private void GetSearchResults()
        {
            if (value == null) return;

            EditorGUILayout.BeginVertical();

            scroll = EditorGUILayout.BeginScrollView(scroll);
            foreach (KeyValuePair<string, string> element in dictionary)
            {
                if (element.Key.ToLower().Contains(value.ToLower()) || element.Value.ToLower().Contains(value.ToLower()))
                {
                    EditorGUILayout.BeginHorizontal("box");

                    GUIContent content = new GUIContent("Close");

                    if (GUILayout.Button(content, GUILayout.MaxWidth(20), GUILayout.MaxHeight(20)))
                    {
                        if (EditorUtility.DisplayDialog($"Remove Key {element.Key}?",
                            $"This will remove the element from the Localization file, are you sure?",
                            "Confirm", "Back"))
                        {
                            LocalizationManager.Remove(element.Key);
                            AssetDatabase.Refresh();
                            LocalizationManager.Init();
                            dictionary = LocalizationManager.GetDictionaryForEditor();
                        }
                    }

                    EditorGUILayout.TextField(element.Key);
                    EditorGUILayout.LabelField(element.Value);

                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}
