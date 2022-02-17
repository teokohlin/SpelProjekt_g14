using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogues[] dialogues;
    public int dialogueIndex;

    [System.Serializable]
    public struct Dialogues
    {
        public Dialogue[] dialogue;
    }
    public void TriggerDialogue()
    {
        if (dialogueIndex >= dialogues.Length)
        {
            return;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[dialogueIndex].dialogue);
        dialogueIndex++;

    }

}
