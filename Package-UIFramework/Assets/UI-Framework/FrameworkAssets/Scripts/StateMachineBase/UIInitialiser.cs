using UnityEngine;

namespace UIFramework.StateMachine
{
    public class UIInitialiser : MonoBehaviour
    {
        [SerializeField] private UIStateMachine stateMachine = null;
        [SerializeField] private UIState startingState = null;
        [SerializeField] private bool autoStart = true;

        private void Start()
        {
            if (autoStart)
                Init();
        }

        public void Init()
        {
            stateMachine.Init(startingState);
        }
    }
}