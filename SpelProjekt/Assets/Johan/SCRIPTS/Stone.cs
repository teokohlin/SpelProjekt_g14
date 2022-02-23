using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Choppable
{

    public override void LoseHealth(int damage)
    {
        audioManager.interactablesAudio.StoneAudio(this.gameObject);
        base.LoseHealth(damage);
    }

    public override void Die()
    {
        //audioManager.interactablesAudio.StoneAudio(this.gameObject);
        //PlayDieAnimation();
        base.Die();

    }
}
