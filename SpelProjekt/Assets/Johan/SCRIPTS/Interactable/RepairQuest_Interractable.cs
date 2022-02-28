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

    public override void InteractWith(PlayerController pc)
    {
        GetComponent<QuestGiver>().TriggerDialogue();
        GetComponent<QuestGiver>().TryStartQuest();
        
        GetComponent<QuestGiver>().InterractedWith();
        this.pc = pc;
        if (isQuest)
        {
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
