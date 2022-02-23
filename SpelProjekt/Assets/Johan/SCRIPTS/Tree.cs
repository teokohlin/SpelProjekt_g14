using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inte riktigt bestämt mig om man behöver ha skript som ärver av "choppable"
//eller om man bara ska göra den generell

public class Tree : Choppable
{
    public GameObject spawner;
    public GameObject stubbe;
    public override void LoseHealth(int damage)
    {
        audioManager.interactablesAudio.TreeAudio(this.gameObject);
        base.LoseHealth(damage);
    }


    public override void Die()
    {
        if (spawner != null && stubbe != null)
        {
            if (dead)
            {
                Instantiate(stubbe, spawner.transform.position, spawner.transform.rotation);
                base.Die();
            }
        }
        else
            //PlayDieAnimation();
        base.Die();
    }
}
