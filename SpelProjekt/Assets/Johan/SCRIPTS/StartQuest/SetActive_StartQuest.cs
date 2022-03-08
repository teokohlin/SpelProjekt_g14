using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive_StartQuest : StartQuest
{

    public override void StartSomething()
    {
        base.StartSomething();

        gameObject.SetActive(true);

        if (TryGetComponent(out Interactable interactable))
        {
            interactable.canNotInteract = true; //Gör så dess "InteractWith" inte gör mer än att
                                                //invoka unityaction när man interragerar
        }
    }
}
