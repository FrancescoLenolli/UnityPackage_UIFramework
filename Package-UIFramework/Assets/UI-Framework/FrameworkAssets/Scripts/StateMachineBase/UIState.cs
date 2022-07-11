using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIFramework.StateMachine
{
    public class UIState : MonoBehaviour
    {
        protected UIStateMachine owner;
        private UIView uiView;

        /// <summary>
        /// Called when initialising the State Machine, much like the Start and Awake functions.
        /// </summary>
        /// <param name="owner"></param>
        public virtual void PrepareState(UIStateMachine owner, UIView uiView = null)
        {
            if (!this.owner) this.owner = owner;
            if (!this.uiView) this.uiView = uiView;
        }

        public virtual void ShowState()
        {
            uiView.ShowView();
        }

        public virtual void HideState()
        {
            uiView.HideView();
        }

        /// <summary>
        /// Safely load Scene. TODO: Move this method outside UIState.
        /// </summary>
        /// <param name="index"></param>
        public virtual void LoadScene(int index)
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