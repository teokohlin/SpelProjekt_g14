using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger_Interractable : Interactable
{

    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith(pc);

        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();
    }
}
