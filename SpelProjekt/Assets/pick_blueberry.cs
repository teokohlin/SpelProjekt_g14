using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_blueberry : Interactable
{
    public Player player;
    public DayNightCycle dnc;

    public int berryAmount = 1;

    public int daysUntilGrowth;
    private int counter;

    public GameObject berrys;
    private bool berrysActive = true;
    public override void InteractWith(PlayerController pc)
    {
        //här är allt som ska hända när man högerklickar

        if (berrysActive == true)
        {
            player.AddResource(berryAmount, dType.food);
            berrys.SetActive(false);
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
        else if(berrysActive == false && counter == 0) {
            berrysActive = true;
            counter = daysUntilGrowth;
            berrys.SetActive(true);
        }
    }
}
