﻿using UIFramework.StateMachine;

namespace UIFramework.Test
{
    public class UIState_Test : UIState
    {
        protected UIRoot_Test root;
        public override void PrepareState(UIStateMachine owner, UIView uiView)
        {
            base.PrepareState(owner, uiView);
            if (!root)
                root = (UIRoot_Test)this.owner.Root;
        }
    }
}
