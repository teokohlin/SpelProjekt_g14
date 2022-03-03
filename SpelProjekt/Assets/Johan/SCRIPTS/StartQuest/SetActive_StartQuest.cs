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
            interactable.canNotInteract = true; //G�r s� dess "InteractWith" inte g�r mer �n att
                                                //invoka unityaction n�r man interragerar
        }
    }
}
