using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitHole_Interractable : Interactable
{
    public GameObject door;
    public UnityAction interractedWith;
    public override void InteractWith(PlayerController pc)
    {
        door.SetActive(true);
        interractedWith?.Invoke();
    }
}
