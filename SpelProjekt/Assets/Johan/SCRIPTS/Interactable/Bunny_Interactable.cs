using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Interactable : Interactable
{
    public GameObject exclamationMark;

    public override void InteractWith(PlayerController pc)
    {
        base.InteractWith(pc);
        //GetComponent<DialogueTrigger>().TriggerDialogue();
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();



    }
}
