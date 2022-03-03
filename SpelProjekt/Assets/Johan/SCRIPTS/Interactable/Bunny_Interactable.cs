using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Interactable : Interactable
{
    //public GameObject exclamationMark;

    public override void InteractWith(PlayerController pc)
    {
        if (enabled == false)
        {
            return;
        }


        base.InteractWith(pc);

        if (canNotInteract)
        {
            return;
        }

        //GetComponent<DialogueTrigger>().TriggerDialogue();
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();



    }

    private void Update()
    {
        
    }
}
