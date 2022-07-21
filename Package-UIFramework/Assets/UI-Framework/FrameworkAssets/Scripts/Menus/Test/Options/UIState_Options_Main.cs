using UIFramework;
using UIFramework.StateMachine;
using UnityEngine;

namespace UIFramework.Test
{
    public class UIState_Options_Main : UIState_Options
    {
        private UIView_Options_Main view;

        public override void PrepareState(UIStateMachine owner)
        {
            base.PrepareState(owner);
            view = root.ViewMain;
            SetView(view);

            view.OnCloseOptions += CloseOptions;
        }

        private void CloseOptions()
        {
            Time.timeScale = 1;
            Hide();
            OptionsMenuManager.Instance.OptionsOpen = false;
        }
    }
}
