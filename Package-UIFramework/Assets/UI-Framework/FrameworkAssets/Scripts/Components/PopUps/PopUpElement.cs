using UnityEngine;
using UnityEngine.EventSystems;

namespace UIFramework.Components
{
    public class PopUpElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("Text for the PopUp for this Object.")]
        [TextArea(2, 10)]
        [SerializeField] private string popUpDescription = "PopUp Description.";

        private PopUpObject popUpPrefab;
        private PopUpObject popUpObject;

        private void Awake()
        {
            popUpPrefab = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!popUpPrefab)
            {
                Debug.LogWarning($"PopUp prefab not found." +
                    $"Make sure you assign one in the inspector.");
                return;
            }

            popUpObject = Instantiate(popUpPrefab, transform, false);
            popUpObject.SetText(popUpDescription);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (popUpObject)
                Destroy(popUpObject.gameObject);
        }
    }
}
