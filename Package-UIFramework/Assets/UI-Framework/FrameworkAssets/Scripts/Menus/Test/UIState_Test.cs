using UIFramework.StateMachine;

public class UIState_Test : UIState
{
    protected UIRoot_Test root;
    public override void PrepareState(UIStateMachine owner)
    {
        base.PrepareState(owner);
        if (!root)
            root = (UIRoot_Test)this.owner.Root;
    }
}
