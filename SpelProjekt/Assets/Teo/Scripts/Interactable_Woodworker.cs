using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable_Woodworker : Interactable
{
    public GameObject MonsterMenu;
    
    public override void InteractWith(PlayerController pc)
    {
        if (enabled == false)
        {
            return;
        }
        if (isQuest)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        else if (!isQuest)
        {
            MonsterMenu.SetActive(true);
        }
        base.InteractWith(pc);

    }
    
    public void DialogueButtonPressed()
    {
        //Lägga detta under en funktion som kallas på av knapp
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();
    }
}
