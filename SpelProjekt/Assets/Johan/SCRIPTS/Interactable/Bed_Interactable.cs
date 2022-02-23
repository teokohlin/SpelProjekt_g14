using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Interactable : Interactable
{
    public BlackScreenManager screen;
    public DayManager dayManager;
    public DayNightCycle dnc;
    private void Start()
    {
        screen = FindObjectOfType<BlackScreenManager>();
        dayManager = FindObjectOfType<DayManager>();
        dnc = FindObjectOfType<DayNightCycle>();
    }

    public override void InteractWith(PlayerController pc)
    {
        pc.SetLockMovement(true);
        screen.Fade(true);
        StartCoroutine(ChangeDay(pc));
    }

    public IEnumerator ChangeDay(PlayerController pc)
    {
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        dnc.Invoke(1);
        pc.player.RefillEnergy();
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        pc.SetLockMovement(false);
    }
}
