using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject_Interactable : Interactable
{
    public override void InteractWith(PlayerController pc)
    {
        base.InteractWith(pc);
        gameObject.SetActive(false);
    }
}
