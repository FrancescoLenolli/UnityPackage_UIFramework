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
        private bool showView = true;

        public virtual void Show()
        {
            SetVisibility(true);
        }

        public virtual void Hide()
        {
            SetVisibility(false);
        }

        private CanvasGroup GetCanvasGroup()
        {
            if (!canvasGroup)
                canvasGroup = GetComponent<CanvasGroup>();

            return canvasGroup;
        }

        private void SetVisibility(bool isVisible)
        {
            UIUtils.ShowObject(GetCanvasGroup(), isVisible);
        }

        [ContextMenu("Change Visibility")]
        private void ChangeVisibility()
        {
            showView = !showView;
            SetVisibility(showView);
        }
    }
}
