using UIFramework.StateMachine;
using UnityEngine;

namespace UIFramework.Test
{
    public class UIRoot_Options : UIRoot
    {
        [SerializeField]
        private UIView_Options_Main optionsMain = null;

        public UIView_Options_Main ViewMain { get => optionsMain; }
    }
}
