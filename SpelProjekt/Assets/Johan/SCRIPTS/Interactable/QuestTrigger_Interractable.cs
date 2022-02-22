using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuestGiver))]
public class QuestTrigger_Interractable : Interactable
{
    public GameObject canvas;

    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith(pc);

        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();
    }
}
