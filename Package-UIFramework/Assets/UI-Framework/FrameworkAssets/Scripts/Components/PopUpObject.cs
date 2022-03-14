using System.Collections;
using TMPro;
using UnityEngine;

namespace UIFramework.Components
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PopUpObject : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;
        [Tooltip("Check if the PopUp will show up with a fade effect.")]
        [SerializeField] private bool canFade = true;
        [SerializeField] private float fadeTime = 1.0f;

        private CanvasGroup canvasGroup;
        private RectTransform rectTransform;
        private Vector2 offsetToMousePosition;
        private Vector3 lastMousePosition;
        private bool mouseMoved = false;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();

            offsetToMousePosition = new Vector2(rectTransform.rect.width * 0.5f, rectTransform.rect.height * 0.5f);
            lastMousePosition = Input.mousePosition;

            ShowPopUp();
        }

        private void LateUpdate()
        {
            mouseMoved = lastMousePosition != Input.mousePosition;

            Vector3 newPosition = new Vector3
                (Input.mousePosition.x + offsetToMousePosition.x, Input.mousePosition.y + offsetToMousePosition.y, 0);
            transform.position = newPosition;
        }

        public void SetText(string newText)
        {
            label.text = newText;
        }

        private void ShowPopUp()
        {
            canvasGroup.alpha = 0;
            if (canFade) StartCoroutine(FadeInRoutine());
            else canvasGroup.alpha = 1;
        }

        private IEnumerator FadeInRoutine()
        {
            yield return new WaitForSeconds(1f);

            while (true)
            {
                if (!mouseMoved)
                {
                    if (canvasGroup.alpha < 1f)
                        canvasGroup.alpha += Time.deltaTime * fadeTime;
                    yield return null;
                }
                else canvasGroup.alpha = 0;

                yield return null;
            }
        }
    }
}
