using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interactable : Interactable
{

    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith();

        //refill energy
        pc.player.RefillEnergy();
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
