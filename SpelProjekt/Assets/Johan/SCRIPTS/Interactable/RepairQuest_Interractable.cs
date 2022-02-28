using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairQuest_Interractable : Interactable
{
    public GameObject canvas;
    private bool canvasOpen;
    //public bool questCompleted;
    private PlayerController pc;
    [Header("Objektet som ska aktiveras när denna avaktiveras")]
    public GameObject repairObject;
    [Header("Objektet som ska replaceas, t.ex. gamla brunnen")]
    public GameObject removeObject;
    [Header("Repair Cost")]
    public int repairCost;
    public dType resourceType;
    [HideInInspector]
    public QuestGiver questGiver;

    public override void InteractWith(PlayerController pc)
    {
        if (GetComponent<QuestGiver>() != null) //Ifall man vill att objektet själv ska starta questet
        {
            GetComponent<QuestGiver>().TriggerDialogue();
            GetComponent<QuestGiver>().TryStartQuest();
            GetComponent<QuestGiver>().InterractedWith();

        }
        //else if (isQuest) //om det startas av någon annan. denna blir dock den som spelas efter första interraktionen
        //{

        //} 


        this.pc = pc;
        if (isQuest)
        {
            questGiver.TriggerDialogue();
            questGiver.TryStartQuest();
        
            questGiver.InterractedWith();

            canvas.SetActive(true);
            canvasOpen = true;
        }

    }
    public override void Repair() //koppla knappen i canvaset till denna funktionen
    {
        if (pc.player.ReturnAmount(resourceType) < repairCost)
        {
            return;
        }
        pc.player.AddResource(-repairCost, resourceType);


        base.Repair();
        repairObject.SetActive(true);


        canvas.SetActive(false);
        canvasOpen = false;
        if (removeObject != null)
        {
            removeObject.SetActive(false);
        }



    }
    private void Update()
    {
        if (canvasOpen)
        {
            if (Vector3.Distance(transform.position, pc.gameObject.transform.position) > 10)
            {
                canvas.SetActive(false);
                canvasOpen = false;
            }
        }
    }
}
