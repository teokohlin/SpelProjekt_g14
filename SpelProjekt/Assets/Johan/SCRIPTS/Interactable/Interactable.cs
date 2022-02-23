using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public UnityAction interractedWith;
    [HideInInspector]
    public bool isQuest = false;


    public virtual void InteractWith(PlayerController pc)
    {
        interractedWith?.Invoke();

    }

}
