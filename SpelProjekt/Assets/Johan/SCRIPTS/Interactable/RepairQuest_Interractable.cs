using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairQuest_Interractable : Interactable
{
    public GameObject canvas;
    public bool questCompleted;

    public override void InteractWith(PlayerController pc)
    {
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        
        GetComponent<QuestGiver>().InterractedWith();
    }
}
