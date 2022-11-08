using UIFramework.StateMachine;
using UIFramework.Utilities;
using UnityEngine;

namespace UIFramework.Test
{
    public class UIState_Test_Main : UIState
    {
        private UIView_Test_Main view;

        public override void PrepareState(UIStateMachine owner)
        {
            base.PrepareState(owner);
            view = owner.Root.GetView<UIView_Test_Main>();
            SetView(view);

            view.OnStartGame += () => SceneLoader.LoadScene(1);
            view.OnQuitGame += Application.Quit;
            view.OnOpenOptions += OpenOptions;
        }

        private void OpenOptions()
        {
            Debug.Log("Opening Options");
        }
    }
}