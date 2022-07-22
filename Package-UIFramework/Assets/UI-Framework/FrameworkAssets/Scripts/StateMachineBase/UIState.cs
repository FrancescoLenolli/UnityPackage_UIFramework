using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIFramework.StateMachine
{
    public class UIState : MonoBehaviour
    {
        protected UIStateMachine owner;
        private UIView baseView;

        /// <summary>
        /// Called when initialising the State Machine, much like the Start and Awake functions.
        /// </summary>
        /// <param name="owner"></param>
        public virtual void PrepareState(UIStateMachine owner)
        {
            if (!this.owner) this.owner = owner;
        }

        public virtual void Show()
        {
            baseView.Show();
        }

        public virtual void Hide()
        {
            baseView.Hide();
        }

        protected void SetView(UIView view)
        {
            if (!this.baseView) this.baseView = view;
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