using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_blueberry : Interactable
{
    public Player player;
    public DayNightCycle dnc;

    public int berryAmount = 1;

    public int daysUntilGrowth;
    public int counter;

    public GameObject berries;
    private bool berrysActive = true;
    public override void InteractWith(PlayerController pc)
    {
        //här är allt som ska hända när man högerklickar

        base.InteractWith(pc);

        if (berrysActive == true)
        {
            player.AddResource(berryAmount, dType.food);
            berries.SetActive(false);
            berrysActive = false;
        }

    }


    public void Start()
    {
        dnc = FindObjectOfType<DayNightCycle>();
        dnc.DayPast += Check_Day;
        counter = daysUntilGrowth;
    }
    public void Check_Day()
    {
        if (berrysActive == false)
        {
            counter--;
        }
        if(berrysActive == false && counter < 1) {
            berrysActive = true;
            counter = daysUntilGrowth;
            berries.SetActive(true);
        }
    }
}
