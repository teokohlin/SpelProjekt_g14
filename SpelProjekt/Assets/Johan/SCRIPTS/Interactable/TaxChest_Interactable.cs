using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxChest_Interactable : Interactable
{
    public GameObject taxCanvas;
    private bool canvasOpen;
    private TaxChest taxChest;
    private PlayerController pc;
    private DialogueTrigger trigger;

    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
        taxChest = GetComponent<TaxChest>();
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape) && taxCanvas.activeSelf == true)
        //{
        //    taxCanvas.SetActive(false);
        //    pc.SetLockMovement(false);
        //}

        if (canvasOpen)
        {
            if (Vector3.Distance(transform.position, pc.gameObject.transform.position) > 10)
            {
                taxCanvas.SetActive(false);
                canvasOpen = false;
            }
        }


    }

    public override void InteractWith(PlayerController pc)
    {
        trigger.TriggerDialogue();
        taxCanvas.SetActive(true);
        canvasOpen = true;
        taxChest.UpdateTaxChestTexts();
        //pc.SetLockMovement(true);
        //if (taxCanvas.activeSelf == false)
        //{

        //}

    }
}
