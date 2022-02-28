using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogues[] dialogues;
    public int dialogueIndex;
    public bool loop = false;

    [System.Serializable]
    public struct Dialogues
    {
        public Dialogue[] dialogue;
    }
    public void TriggerDialogue()
    {
        if (dialogueIndex >= dialogues.Length && !loop)
        {
            return;
        }
        else if (dialogueIndex >= dialogues.Length) //Om loop = true, s� s� loopas den n�r den g�r �ver antalet dialoger
        {
            dialogueIndex = 0;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues[dialogueIndex].dialogue);
        dialogueIndex++;

    }

}
