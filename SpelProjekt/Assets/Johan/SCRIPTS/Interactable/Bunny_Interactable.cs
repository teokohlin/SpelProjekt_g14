using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Interactable : Interactable
{
    
    public GameObject MonsterMenu;
    public override void InteractWith(PlayerController pc)
    {
        if (enabled == false)
        {
            return;
        }


        base.InteractWith(pc);
        MonsterMenu.SetActive(true);


        if (canNotInteract) //Denna hindrar basically......   Denna == dialogknappen �r disabled
        {
            return;
        }

        //GetComponent<DialogueTrigger>().TriggerDialogue();
        
        //L�gga detta under en funktion som kallas p� av knapp
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();



    }

    private void Update()
    {
        
    }
}
