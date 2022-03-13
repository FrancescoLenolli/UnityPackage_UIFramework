using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework.Utilities
{
    public static class Utils
    {
        public static void ShowObject(CanvasGroup canvasGroup, bool isVisible)
        {
            canvasGroup.alpha = isVisible ? 1 : 0;
            canvasGroup.blocksRaycasts = isVisible;
            canvasGroup.interactable = isVisible;
        }
    }
}
