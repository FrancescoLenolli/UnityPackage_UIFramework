using UIFramework.StateMachine;
using UnityEngine;

namespace UIFramework.Test
{
    public class UIRoot_Test : UIRoot
    {
        [SerializeField] private UIView_Test_Main mainView = null;

        public UIView_Test_Main Main { get => mainView; private set => mainView = value; }
    }
}
