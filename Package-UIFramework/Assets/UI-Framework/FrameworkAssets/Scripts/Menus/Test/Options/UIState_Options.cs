using UIFramework.StateMachine;

namespace UIFramework.Test
{
    public class UIState_Options : UIState
    {
        protected UIRoot_Options root;

        public override void PrepareState(UIStateMachine owner, UIView uiView)
        {
            base.PrepareState(owner, uiView);
            if (!root)
                root = (UIRoot_Options)owner.Root;
        }
    }
}
