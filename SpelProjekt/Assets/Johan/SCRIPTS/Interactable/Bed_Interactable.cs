using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Interactable : Interactable
{
    public override void InteractWith(PlayerController pc)
    {
        pc.player.RefillEnergy();
    }
}
