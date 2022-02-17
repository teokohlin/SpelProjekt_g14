using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogues[] dialogues;
    public int dialogueIndex;
    bool outOfDialogue;

    [System.Serializable]
    public struct Dialogues
    {
        public Dialogue[] dialogue;
    }
    public void TriggerDialogue()
    {
        if (outOfDialogue)
        {
            return;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[dialogueIndex].dialogue);
        dialogueIndex++;
        if (dialogueIndex > dialogues.Length)
        {
            outOfDialogue = true;
        }
    }

}
