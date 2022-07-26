using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private bool playOnStart = false;
    [SerializeField] private Dialogue dialogue = null;
    [Space(10)]
    [SerializeField] private GameObject dialogueCanvas = null;
    [Tooltip("Text for the dialogue texts.")]
    [SerializeField] private TextMeshProUGUI dialogueSection = null;
    [Tooltip("Text for the current character's name.")]
    [SerializeField] private TextMeshProUGUI characterName = null;
    [Space(10)]
    [Tooltip("Delay between text's single characters being displayed.")]
    [SerializeField] private float charactersDelay = 0.07f;
    [Tooltip("Can the dialogue play itself with no player input required?")]
    [SerializeField] private bool canAutoplay = false;
    [Tooltip("Autoplay's delay between texts.")]
    [SerializeField] private float dialogueDelay = 1f;

    private static DialogueSystem Instance;
    private Dialogue currentDialogue;
    private bool isCurrentDialogueEnded = true;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject.transform.root);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(playOnStart)
        SetDialogue(dialogue);
    }

    public void SetDialogue(Dialogue newDialogue)
    {
        if (!isCurrentDialogueEnded)
            return;

        currentDialogue = newDialogue;
        StartDialogue();
    }

    public void AutoPlayDialogue()
    {
        canAutoplay = !canAutoplay;
    }

    private void StartDialogue()
    {
        dialogueCanvas.SetActive(true);
        StartCoroutine(ShowDialogueRoutine());
    }

    private void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
    }

    private IEnumerator ShowDialogueRoutine()
    {
        isCurrentDialogueEnded = false;
        int index = 0;
        int lastIndex = currentDialogue.sections.Count;
        bool canEndDialogue = false;

        while (!canEndDialogue)
        {
            bool isDialogueEnded = index >= lastIndex;

            if (!isDialogueEnded)
            {
                characterName.text = currentDialogue.sections[index].characterName;
                dialogueSection.text = dialogueSection.text.Remove(0);
                foreach (char character in currentDialogue.sections[index].text)
                {
                    if(Input.GetKeyDown(KeyCode.R))
                    {
                        Debug.Log("De'");
                    }
                    dialogueSection.text += character;
                    yield return new WaitForSeconds(charactersDelay);
                }
                ++index;
            }

            if (!canAutoplay)
            {
                while (!Input.GetKeyDown(KeyCode.Space) && !canAutoplay)
                { yield return null; }
            }
            else if (!isDialogueEnded)
            {
                yield return new WaitForSeconds(dialogueDelay);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isDialogueEnded)
            {
                canEndDialogue = true;
                EndDialogue();
            }

            yield return null;
        }

        isCurrentDialogueEnded = true;
        yield return null;
    }
}
