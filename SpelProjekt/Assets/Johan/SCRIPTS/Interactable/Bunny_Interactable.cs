using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Interactable : Interactable
{
    public GameObject exclamationMark;
    public bool tillfalligQuestStoppare;

    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith();
        GetComponent<DialogueTrigger>().TriggerDialogue();


        if (!tillfalligQuestStoppare)
        {
            tillfalligQuestStoppare = true;
            GetComponent<QuestGiver>().StartQuest();
            exclamationMark.SetActive(false);
        }

    }
}
