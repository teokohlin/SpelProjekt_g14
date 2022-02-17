using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Woodworker : Interactable
{
    public GameObject window;
    public override void InteractWith(PlayerController pc)
    {
        window.SetActive(true);
    }
}
