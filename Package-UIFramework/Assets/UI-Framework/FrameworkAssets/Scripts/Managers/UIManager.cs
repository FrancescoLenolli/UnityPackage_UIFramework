using UIFramework.Components;
using UIFramework.StateMachine;
using UnityEngine;

namespace UIFramework
{
    public class UIManager : Singleton<UIManager>
    {
        [Tooltip("Prefab for the game's Options Menu")]
        [SerializeField] private UIStateMachine optionsMenuPrefab = null;
        [SerializeField] private PopUpObject popUpPrefab = null;

        private UIStateMachine optionsMenu = null;
        private bool optionsOpen = false;

        public bool OptionsOpen { get => optionsOpen; set => optionsOpen = value; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenOptions();
            }
        }

        public PopUpObject GetPopUp()
        {
            return popUpPrefab;
        }

        public void OpenOptions()
        {
            if (!optionsOpen)
            {
                if (!optionsMenu)                                               
                {
                    optionsMenu = Instantiate(optionsMenuPrefab);
                    optionsMenu?.FirstStart();
                }

                optionsMenu.ChangeState(optionsMenu.StartingType);
                Time.timeScale = 0;
                optionsOpen = true;
            }
            else
            {
                if (optionsMenu)
                {
                    optionsMenu.CurrentState.HideState();
                    Time.timeScale = 1;
                    optionsOpen = false;
                }
            }
        }
    }
}
