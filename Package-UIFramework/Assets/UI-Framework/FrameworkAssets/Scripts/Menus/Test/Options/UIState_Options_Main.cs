using UIFramework;
using UIFramework.StateMachine;
using UnityEngine;

namespace UIFramework.Test
{
    public class UIState_Options_Main : UIState_Options
    {
        private UIView_Options_Main view;

        public override void PrepareState(UIStateMachine owner, UIView uiView)
        {
            view = root.ViewMain;
            base.PrepareState(owner, view);

            view.OnCloseOptions += CloseOptions;
        }

        private void CloseOptions()
        {
            Time.timeScale = 1;
            HideState();
            OptionsMenuManager.Instance.OptionsOpen = false;
        }
    }
}
