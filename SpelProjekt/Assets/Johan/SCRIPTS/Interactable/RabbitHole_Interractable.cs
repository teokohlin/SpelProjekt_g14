using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitHole_Interractable : Interactable
{
    public GameObject door;

    public override void InteractWith(PlayerController pc)
    {
        base.InteractWith(pc);
        if (isQuest)
        {
            door.SetActive(true);
        }
    }
}
