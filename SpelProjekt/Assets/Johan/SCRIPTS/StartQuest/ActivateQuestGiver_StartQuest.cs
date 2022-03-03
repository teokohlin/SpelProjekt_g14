using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuestGiver_StartQuest : StartQuest
{
    public override void StartSomething()
    {
        base.StartSomething();



        GetComponent<QuestGiver>().enabled = true;
        GetComponent<Interactable>().enabled = true;

        if (TryGetComponent(out Interactable interactable))
        {
            StopAllCoroutines();
            StartCoroutine(Wait(interactable));

            //interactable.canNotInteract = false; //G�r s� dess "InteractWith" inte g�r mer �n att
                                                //invoka unityaction n�r man interragerar
        }
    }

    IEnumerator Wait(Interactable interactable)
    {
        yield return new WaitForEndOfFrame();
        interactable.canNotInteract = false;
    }
}
