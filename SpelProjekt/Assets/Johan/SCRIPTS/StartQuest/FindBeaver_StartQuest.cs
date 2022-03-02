using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBeaver_StartQuest : StartQuest
{
    public override void StartSomething()
    {
        base.StartSomething();

        gameObject.SetActive(true);
    }
}
