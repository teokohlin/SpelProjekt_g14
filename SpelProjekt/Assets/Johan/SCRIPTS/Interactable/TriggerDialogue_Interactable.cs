using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class TriggerDialogue_Interactable : Interactable
{
    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public override void InteractWith(PlayerController pc)
    {
        dialogueTrigger.TriggerDialogue();
    }
}
