using UIFramework.StateMachine;

namespace UIFramework.Test
{
    public class UIState_Options : UIState
    {
        protected UIRoot_Options root;

        public override void PrepareState(UIStateMachine owner)
        {
            base.PrepareState(owner);
            if (!root)
                root = (UIRoot_Options)owner.Root;
        }
    }
}
