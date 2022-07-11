using System;
using UIFramework.StateMachine;

namespace UIFramework.Test
{
    public class UIView_Options_Main : UIView
    {
        private Action onCloseOptions;

        public Action OnCloseOptions { get => onCloseOptions; set => onCloseOptions = value; }

        public void CloseOptions()
        {
            onCloseOptions?.Invoke();
        }
    }
}