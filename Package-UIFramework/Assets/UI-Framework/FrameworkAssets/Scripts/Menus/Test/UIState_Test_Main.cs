using UIFramework;
using UIFramework.StateMachine;
using UnityEngine;

public class UIState_Test_Main : UIState_Test
{
    private UIView_Test_Main view;

    public override void PrepareState(UIStateMachine owner)
    {
        base.PrepareState(owner);
        view = root.mainView;
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
        UIManager.Instance?.OpenOptions();
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
