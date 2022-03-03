using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public UnityAction interractedWith;
    public UnityAction repaired;
    [HideInInspector]
    public bool isQuest = false;
    [HideInInspector]
    public bool canNotInteract = false; //Tänker att i varje child, att denna kommer efter base.InteractWith
                                        //SÅ om man interragerar med ett objekt så invokas unityaction, men inget
                                        //av det i interact ska hända
    public virtual void InteractWith(PlayerController pc)
    {

        interractedWith?.Invoke();

    }
    public virtual void Repair()
    {
        repaired?.Invoke();
    }

}
