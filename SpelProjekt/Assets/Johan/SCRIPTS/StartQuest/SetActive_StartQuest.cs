using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive_StartQuest : StartQuest
{

    public override void StartSomething()
    {
        base.StartSomething();

        gameObject.SetActive(true);
    }
}
