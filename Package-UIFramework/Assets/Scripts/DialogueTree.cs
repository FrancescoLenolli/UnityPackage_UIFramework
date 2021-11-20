using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/DialogueSystem/DialogueTree", fileName = "NewDialogueTree")]
public class DialogueTree : ScriptableObject
{
    public enum CharacterStatus { Normal, Angry }

    [System.Serializable]
    public struct Dialogue
    {
        public string characterName;
        public CharacterStatus status;
        [TextArea]
        public string text;
    }

    public List<Dialogue> dialogues = new List<Dialogue>();
}
