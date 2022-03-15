using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIFramework.Components
{
    public class Container : UIComponent
    {
        public void EnableAllButtons(bool isInteractable)
        {
            foreach(Transform child in transform)
            {
                CustomButton button = child.GetComponent<CustomButton>();
                if (button)
                    button.EnableButton(isInteractable);
            }
        }
    }
}
