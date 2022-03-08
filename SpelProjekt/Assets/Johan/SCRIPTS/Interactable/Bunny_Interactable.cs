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

        if (!isQuest)
        {
            MonsterMenu.SetActive(true);
        }

        base.InteractWith(pc);
        
        
        

        /*
        if (canNotInteract) //Denna hindrar basically......   Denna == dialogknappen är disabled
        {
            return;
        }
        */
        //GetComponent<DialogueTrigger>().TriggerDialogue();
        




    }

    private void Update()
    {
        
    }


    public void DialogueButtonPressed()
    {
        //Lägga detta under en funktion som kallas på av knapp
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        GetComponent<QuestGiver>().InterractedWith();
    }
    
}
