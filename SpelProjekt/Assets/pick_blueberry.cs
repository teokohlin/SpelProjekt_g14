using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_blueberry : Interactable
{
    public Player player;

    public int berryAmount = 1;
    public override void InteractWith(PlayerController pc)
    {
        //här är allt som ska hända när man högerklickar
        Debug.Log("Hej Teo");
        player.AddResource(berryAmount, dType.food);
    }
}
