using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_StartQuest : StartQuest
{


    [SerializeField] private Frog frog;

    public override void StartSomething()
    {
        base.StartSomething();

        frog.enabled = true;

    }
}
