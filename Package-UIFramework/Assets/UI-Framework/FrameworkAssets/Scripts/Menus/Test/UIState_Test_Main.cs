using UIFramework;
using UIFramework.StateMachine;
using UnityEngine;

namespace UIFramework.Test
{
    public class UIState_Test_Main : UIState
    {
        private UIView_Test_Main view;

        public override void PrepareState(UIStateMachine owner)
        {
            base.PrepareState(owner);
            view = owner.Root.Get<UIView_Test_Main>();
            SetView(view);

            view.OnStartGame += StartGame;
            view.OnOpenOptions += OpenOptions;
            view.OnQuitGame += QuitGame;
        }

        private void StartGame()
        {
            LoadScene(1);
        }

        private void OpenOptions()
        {
            Debug.Log("Opening Options");
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}