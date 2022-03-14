using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Frog : Interactable
{
    private Player player;
    private DialogueTrigger dialogueTrigger;
    
    
    [SerializeField]
    private  GameObject exclamationMark;
    [SerializeField]
    private Vector2 interval = new Vector2(-10, 10);

    [SerializeField] private string badCatchMessage;
    [SerializeField] private string decentCatchMessage;
    [SerializeField] private string goodCatchMessage;
    [SerializeField] private string perfectCatchMessage;
    [SerializeField]
    private string fishCatchString;
    [SerializeField]
    private string fishCatchString2;

    private int dailyCatchAmount;
    private bool foodTaken;
    private void Awake()
    {
        FindObjectOfType<DayNightCycle>().DayPast += NewDay;
        player = FindObjectOfType<Player>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        foodTaken = true;
    }


    private void NewDay()
    {
        exclamationMark.SetActive(true);
        foodTaken = false;
        dailyCatchAmount = (int)Random.Range(interval.x,interval.y + 1);
        dailyCatchAmount = (int)Mathf.Clamp(dailyCatchAmount, 0, interval.y);
        
        Debug.Log(dailyCatchAmount);
    }

    public override void InteractWith(PlayerController pc)
    {
        base.InteractWith(pc);

        if (foodTaken)
        {
            return;
        }
        
        exclamationMark.SetActive(false);
        foodTaken = true;
        
        
        ActivateDialogue();
        player.AddFood((int)dailyCatchAmount);

    }

    
    //Ändra dialogen så den beror på mängden fångst
    private void ActivateDialogue()
    {
        if (dailyCatchAmount <= 0)
        {
            dialogueTrigger.dialogues[0].dialogue[0].sentence = badCatchMessage;
        }
        else if (dailyCatchAmount > 0 && dailyCatchAmount < interval.y / 2)
        {
            dialogueTrigger.dialogues[0].dialogue[0].sentence = decentCatchMessage; 
        }
        else if (dailyCatchAmount >= interval.y / 2 && dailyCatchAmount < interval.y)
        {
            dialogueTrigger.dialogues[0].dialogue[0].sentence = goodCatchMessage;
        }
        else if (dailyCatchAmount == interval.y)
        {
            dialogueTrigger.dialogues[0].dialogue[0].sentence = perfectCatchMessage;
        }
        
            
            
            
            
            
        dialogueTrigger.dialogues[0].dialogue[1].sentence =
            fishCatchString + " " + dailyCatchAmount.ToString() + " " + fishCatchString2;
        
        dialogueTrigger.TriggerDialogue();
    }
}
