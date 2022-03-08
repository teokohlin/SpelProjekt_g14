using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNotActive : StartQuest
{

    public override void StartSomething()
    {
        base.StartSomething();

        gameObject.SetActive(false);

        if (TryGetComponent(out Interactable interactable))
        {
            interactable.canNotInteract = false; //Gör så dess "InteractWith" inte gör mer än att
            //invoka unityaction när man interragerar
        }
    }
}
