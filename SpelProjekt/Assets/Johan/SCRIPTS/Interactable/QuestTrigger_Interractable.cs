using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestGiver))]
public class QuestTrigger_Interractable : Interactable
{

    public override void InteractWith(PlayerController pc)
    {
        if (enabled == false)
        {
            return;
        }

        base.InteractWith(pc);

        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();
    }
}
