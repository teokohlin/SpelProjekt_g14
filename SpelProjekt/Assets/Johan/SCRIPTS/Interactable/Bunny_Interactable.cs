using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Interactable : Interactable
{

    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith();

        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
