using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_blueberry : Interactable
{
    //public Player player;
    public DayNightCycle dnc;
    public ParticleSystem ps;

    public int berryAmount = 1;

    public int daysUntilGrowth;
    public int counter;

    public GameObject berries;
    private bool berrysActive = true;

    private AudioManager audioManager;
   
    public override void InteractWith(PlayerController pc)
    {
        //här är allt som ska hända när man högerklickar

        base.InteractWith(pc);

        if (berrysActive == true)
        {
            pc.player.AddResource(berryAmount, dType.food);
            berries.SetActive(false);
            berrysActive = false;

            ps.Play();
        }

    }


    public void Start()
    {
        dnc = FindObjectOfType<DayNightCycle>();
        dnc.DayPast += Check_Day;

        ps = GetComponentInChildren<ParticleSystem>();

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
