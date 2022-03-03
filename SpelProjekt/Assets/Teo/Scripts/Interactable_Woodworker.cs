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
        if (isQuest)
        {
            base.InteractWith(pc);
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        MonsterMenu.SetActive(true);
    }
}
