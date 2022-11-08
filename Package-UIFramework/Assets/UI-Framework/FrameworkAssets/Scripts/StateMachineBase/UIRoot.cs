using System;
using UIFramework.Utilities;
using UnityEngine;

namespace UIFramework.StateMachine
{
    /// <summary>
    /// UI Root class, used for storing references to UI views and other useful components.
    /// </summary>
    public class UIRoot : MonoBehaviour
    {
        private UIView[] views;
        private ServiceLocator serviceLocator;

        /// <summary>
        /// Get a UIView of the specified Type from the current UI.
        /// </summary>
        /// <returns></returns>
        public T GetView<T>() where T : UIView
        {
            // Make sure views has a reference to every UIView.
            if (views == null)
                views = GetComponentsInChildren<UIView>();

            // Store the type for better debugging. Without it the type of T wouldn't be visible.
            T result = null;
            Type type = typeof(T);

            for (int i = 0; i < views.Length; ++i)
            {
                if (views[i].GetType() == type)
                {
                    result = (T)views[i];
                    break;
                }
            }

            if (result == null)
                Debug.LogError($"View of type {type.Name} not found!");

            return result;
        }

        /// <summary>
        /// Get a Component unrelated to the UI.
        /// </summary>
        public T GetService<T>() where T : MonoBehaviour, new()
        {
            if (!serviceLocator)
                serviceLocator = new ServiceLocator();

            return serviceLocator.Get<T>();
        }
    }
}
