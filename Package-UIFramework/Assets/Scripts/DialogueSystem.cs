using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogueSystem : Singleton<DialogueSystem>
{
    public DialogueTree testDialogueTree;

    [SerializeField]
    private GameObject dialogueCanvas = null;
    [SerializeField]
    private TextMeshProUGUI dialogueText = null;
    [SerializeField]
    private float dialogueDelay = 1f;

    private DialogueTree currentDialogueTree;
    private bool canAutoplay = false;

    private void Start()
    {
        SetDialogueTree(testDialogueTree);
    }

    public void SetDialogueTree(DialogueTree newDialogueTree)
    {
        currentDialogueTree = newDialogueTree;
        StartDialogue();
    }

    public void AutoPlayDialogues()
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
        int index = 0;
        int lastIndex = currentDialogueTree.dialogues.Count;
        bool canEndDialogue = false;

        while (!canEndDialogue)
        {
            bool areDialoguesEnded = index >= lastIndex;

            if (!areDialoguesEnded)
            {
                dialogueText.text = dialogueText.text.Remove(0);
                foreach (char character in currentDialogueTree.dialogues[index].text)
                {
                    dialogueText.text += character;
                    yield return new WaitForSeconds(0.05f);
                }
                ++index;
            }

            if (!canAutoplay)
            {
                while (!Input.GetKeyDown(KeyCode.Space) && !canAutoplay)
                { yield return null; }
            }
            else if(!areDialoguesEnded)
            {
                yield return new WaitForSeconds(dialogueDelay);
            }

            if(Input.GetKeyDown(KeyCode.Space) && areDialoguesEnded)
            {
                canEndDialogue = true;
                EndDialogue();
            }

            yield return null;
        }

        yield return null;
    }
}
