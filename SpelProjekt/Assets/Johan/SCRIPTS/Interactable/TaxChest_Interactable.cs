using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxChest_Interactable : Interactable
{
    public GameObject taxCanvas;
    private TaxChest taxChest;
    private PlayerController pc;

    private void Start()
    {
        taxChest = GetComponent<TaxChest>();
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && taxCanvas.activeSelf == true)
        {
            taxCanvas.SetActive(false);
            pc.SetLockMovement(false);
        }



    }

    public override void InteractWith(PlayerController pc)
    {
        if (taxCanvas.activeSelf == false)
        {
            taxCanvas.SetActive(true);
            pc.SetLockMovement(true);
            taxChest.UpdateTaxChestTexts();
        }
        else
        {
            taxCanvas.SetActive(false);
        }
    }
}
