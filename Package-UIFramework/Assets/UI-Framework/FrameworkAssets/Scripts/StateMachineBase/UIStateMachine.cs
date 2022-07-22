using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UIFramework.StateMachine
{
    public class UIStateMachine : MonoBehaviour
    {
        [SerializeField] private UIRoot root = null;
        [SerializeField] private UIState startingState = null;

        private UIState activeState;
        private List<UIState> states;
        private bool statesPrepared = false;

        public UIRoot Root { get => root; set => root = value; }
        public UIState ActiveState { get => activeState; }
        public Type ActiveType { get => activeState.GetType(); }
        public Type StartingType { get => startingState.GetType(); }

        private void Start()
        {
            FirstStart();
        }

        /// <summary>
        /// Initialise the Machine's States starting values.
        /// </summary>
        public void FirstStart()
        {
            if (startingState == null)
            {
                Debug.LogWarning("No Starting State selected!");
                return;
            }    

            if (!statesPrepared)
            {
                states = GetComponents<UIState>().ToList();
                states.ForEach(state => state.PrepareState(this));
                statesPrepared = true;
            }

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
            foreach (UIState state in states)
            {
                if (type == state.GetType())
                {
                    newState = state;
                    break;
                }
            }

            if (activeState) activeState.Hide();
            activeState = newState;
            if (activeState) activeState.Show();
        }
    }
}