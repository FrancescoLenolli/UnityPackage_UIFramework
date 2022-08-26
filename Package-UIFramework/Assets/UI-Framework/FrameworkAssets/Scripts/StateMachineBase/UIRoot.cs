using System;
using UnityEngine;
using UIFramework.Utilities;

namespace UIFramework.StateMachine
{
    /// <summary>
    /// UI Root class, used for storing references to UI views and other useful components.
    /// </summary>
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private UIView[] views = new UIView[0];
        private ServiceLocator serviceLocator = new ServiceLocator();

        /// <summary>
        /// Get a UIView of the specified Type from the current UI.
        /// </summary>
        /// <returns></returns>
        public T Get<T>() where T : UIView
        {
            // Store the type for better debugging. Without it the type of T wouldn't be visible.
            Type type = typeof(T);
            T result = null;

            // Make sure views has a reference to every UIView.
            if (views.Length == 0)
            {
                views = GetComponentsInChildren<UIView>();
            }

            foreach (UIView view in views)
            {
                if (view.GetType() == type)
                {
                    result = (T)view;
                    break;
                }
            }

            if (result == null)
            {
                Debug.LogError($"View of type {type.Name} not found!" +
                    $"Make sure the UIRoot component has a reference to every View" +
                    $"and that the Views needed are in the Scene.");
            }

            return result;
        }

        /// <summary>
        /// Get a Component unrelated to the UI.
        /// </summary>
        public T GetService<T>() where T : MonoBehaviour, new()
        {
            return serviceLocator.Get<T>();
        }
    }
}
