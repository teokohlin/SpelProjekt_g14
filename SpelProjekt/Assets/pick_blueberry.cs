using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_blueberry : Interactable
{
    public Player player;

    public int berryAmount = 1;
    public override void InteractWith(PlayerController pc)
    {
        //h�r �r allt som ska h�nda n�r man h�gerklickar
        Debug.Log("Hej Teo");
        player.AddResource(berryAmount, dType.food);
    }
}
