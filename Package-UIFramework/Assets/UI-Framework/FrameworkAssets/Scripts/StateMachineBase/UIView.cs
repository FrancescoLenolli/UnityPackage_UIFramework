using UIFramework.Utilities;
using UnityEngine;

namespace UIFramework.StateMachine
{
    /// <summary>
    /// Holds logic for the UIView visual elements.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        protected CanvasGroup canvasGroup;

        /// <summary>
        /// Method called to show view.
        /// </summary>
        [ContextMenu("Show View")]
        public virtual void ShowView()
        {
            Utils.ShowObject(GetCanvasGroup(), true);
        }

        /// <summary>
        /// Method called to hide view.
        /// </summary>
        [ContextMenu("Hide View")]
        public virtual void HideView()
        {
            Utils.ShowObject(GetCanvasGroup(), false);
        }

        protected CanvasGroup GetCanvasGroup()
        {
            if (!canvasGroup)
                canvasGroup = GetComponent<CanvasGroup>();

            return canvasGroup;
        }
    }
}
