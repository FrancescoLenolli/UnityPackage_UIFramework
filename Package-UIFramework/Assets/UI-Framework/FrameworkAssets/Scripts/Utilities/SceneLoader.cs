using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIFramework.Utilities
{
    public static class SceneLoader
    {
        /// <summary>
        /// Safely load Scene. TODO: Move this method outside UIState.
        /// </summary>
        /// <param name="index"></param>
        public static void LoadScene(int index)
        {
            if (index > SceneManager.sceneCountInBuildSettings - 1)
            {
                Debug.LogWarning($"No scene with index {index}. Go to File > Build Settings to check the available scenes.");
                return;
            }

            SceneManager.LoadScene(index);
        }
    }
}