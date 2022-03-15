using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIFramework.Components
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : UIComponent
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void EnableButton(bool isInteractable)
        {
            button.interactable = isInteractable;
        }
    }
}
