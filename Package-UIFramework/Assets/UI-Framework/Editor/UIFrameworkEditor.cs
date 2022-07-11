using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIFramework
{
    class UIFrameworkEditor : EditorWindow
    {
        private static GameObject[] gameObjects;
        private Transform parent;
        private GameObject eventSystem;

        [MenuItem("Tools/UI Framework")]
        public static void ShowWindow()
        {
            GetWindow(typeof(UIFrameworkEditor));
            RefreshSelection();
        }

        /// <summary>
        /// Get again the list of Spawnable Elements in the
        /// Resources folder, in case some were added.
        /// </summary>
        private static void RefreshSelection()
        {
            GetObjects();
        }

        private static void GetObjects()
        {
            gameObjects = Resources.LoadAll<GameObject>("UIFrameworkElements");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Select Element to Spawn", EditorStyles.boldLabel);

            EditorGUILayout.Separator();
            EditorGUILayout.Separator();

            DrawObjectsButton();
        }

        private void OnFocus()
        {
            RefreshSelection();
        }

        /// <summary>
        /// Create a Button for every Spawnable Element responsible for
        /// instantiating that Element when clicking on it.
        /// </summary>
        private void DrawObjectsButton()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (!gameObject)
                    continue;

                if (GUILayout.Button($"{gameObject.name}"))
                {
                    SpawnObject(gameObject);
                }
            }
        }

        /// <summary>
        /// Instantiate the Element selected from the UIFramework Editor Window.
        /// </summary>
        private void SpawnObject(GameObject gameObject)
        {
            /*
             * If no UI Element is selected in the Scene Hierarchy, the Element
             * to Instantiate will be placed outside the UI, and it won't be visible.
             */
            parent = Selection.activeTransform;

            if (!parent)
                PrefabUtility.InstantiatePrefab(gameObject);
            else
                PrefabUtility.InstantiatePrefab(gameObject, parent);

            if (!eventSystem && GameObject.Find("EventSystem") == null)
            {
                CreateEventSystem();
            }
        }

        /// <summary>
        /// An Event System needs to be active in Scene for the UI to work properly.
        /// </summary>
        private void CreateEventSystem()
        {
            eventSystem = new GameObject();
            eventSystem.name = "EventSystem";
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }
}
