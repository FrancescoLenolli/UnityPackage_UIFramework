using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIFramework.Components
{
    /// <summary>
    /// Add this component to a Button if you want to call a method continuously
    /// while the Button is being held down.
    /// </summary>
    public class ButtonHeld : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        //TODO: Check if Unity already provides this feature.
        [SerializeField] private UnityEvent onButtonHeld = null;

        private bool canInvokeEvent = false;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            canInvokeEvent = true;
            if (button) StartCoroutine(ButtonHeldRoutine());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canInvokeEvent = false;
        }

        private IEnumerator ButtonHeldRoutine()
        {
            while (canInvokeEvent && button.IsInteractable())
            {
                onButtonHeld?.Invoke();
                yield return null;
            }

            yield return null;
        }
    }
}