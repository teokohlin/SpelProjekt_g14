using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inte riktigt best�mt mig om man beh�ver ha skript som �rver av "choppable"
//eller om man bara ska g�ra den generell

public class Tree : Choppable
{

    public override void Die() 
    {
        //PlayDieAnimation();
        base.Die();
    }
}
