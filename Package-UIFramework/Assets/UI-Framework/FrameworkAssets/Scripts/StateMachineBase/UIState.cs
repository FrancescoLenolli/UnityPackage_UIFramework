using UnityEngine;

namespace UIFramework.StateMachine
{
    public abstract class UIState : MonoBehaviour
    {
        protected UIStateMachine owner;
        private UIView baseView;

        /// <summary>
        /// Called when initialising the State Machine, much like the Start and Awake functions.
        /// </summary>
        public virtual void PrepareState(UIStateMachine owner)
        {
            if (!this.owner)
                this.owner = owner;
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
            if (!baseView)
                baseView = view;
        }
    }
}