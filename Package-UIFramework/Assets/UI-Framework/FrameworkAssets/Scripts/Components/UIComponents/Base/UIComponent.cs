using System.Collections;
using System.Collections.Generic;
using UIFramework.Utilities;
using UnityEngine;

namespace UIFramework.Components
{
    /*
     * Base class from which every UIComponent inherits from.
     */
    [RequireComponent(typeof(CanvasGroup))]
    public class UIComponent : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        public void ShowObject(bool isVisible)
        {
            if (!canvasGroup)
                canvasGroup = GetComponent<CanvasGroup>();

            UIUtils.ShowObject(canvasGroup, isVisible);
        }
    }
}