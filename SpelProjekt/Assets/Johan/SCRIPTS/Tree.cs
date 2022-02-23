using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inte riktigt bestämt mig om man behöver ha skript som ärver av "choppable"
//eller om man bara ska göra den generell

public class Tree : Choppable
{
    public override void LoseHealth(int damage)
    {
        audioManager.interactablesAudio.TreeAudio(this.gameObject);
        base.LoseHealth(damage);
    }


    public override void Die() 
    {

        //PlayDieAnimation();
        base.Die();
    }
}
