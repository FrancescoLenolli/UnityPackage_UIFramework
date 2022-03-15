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

        public virtual void ShowView()
        {
            ChangeView(true);
        }

        public virtual void HideView()
        {
            ChangeView(false);
        }

        protected CanvasGroup GetCanvasGroup()
        {
            if (!canvasGroup)
                canvasGroup = GetComponent<CanvasGroup>();

            return canvasGroup;
        }

        private void ChangeView(bool isVisible)
        {
            UIUtils.ShowObject(GetCanvasGroup(), isVisible);
        }

        [ContextMenu("Show|Hide View")]
        private void ChangeView()
        {
            showView = !showView;
            ChangeView(showView);
        }
    }
}
