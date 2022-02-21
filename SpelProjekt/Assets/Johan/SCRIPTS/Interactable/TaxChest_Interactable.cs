using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxChest_Interactable : Interactable
{
    public GameObject taxCanvas;

    public override void InteractWith(PlayerController pc)
    {
        taxCanvas.SetActive(true);
    }
}
