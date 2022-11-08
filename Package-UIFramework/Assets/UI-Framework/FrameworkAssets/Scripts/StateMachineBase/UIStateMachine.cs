using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UIFramework.StateMachine
{
    public class UIStateMachine : MonoBehaviour
    {
        [SerializeField] private UIRoot root = null;

        private UIState startingState;
        private UIState activeState;
        private List<UIState> states;
        private bool statesPrepared = false;

        public UIRoot Root { get => root; set => root = value; }
        public UIState ActiveState { get => activeState; }
        public Type ActiveType { get => activeState.GetType(); }
        public Type StartingType { get => startingState.GetType(); }

        /// <summary>
        /// Initialise the Machine's States starting values.
        /// </summary>
        public void Init(UIState firstState)
        {
            if (statesPrepared)
                return;

            startingState = firstState;
            states = GetComponents<UIState>().ToList();
            states.ForEach(state => state.PrepareState(this));
            statesPrepared = true;

            ChangeState(startingState.GetType());
        }

        public void ChangeState(Type type)
        {
            if (!statesPrepared)
            {
                Debug.LogWarning($"UI States of {gameObject.name} not initialised.");
                return;
            }

            UIState newState = null;
            newState = states.Find(state => state.GetType() == type);

            activeState?.Hide();
            activeState = newState;
            activeState?.Show();
        }
    }
}