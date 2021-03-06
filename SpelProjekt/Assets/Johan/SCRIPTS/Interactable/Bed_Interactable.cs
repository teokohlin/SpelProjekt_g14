using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Interactable : Interactable
{
    public BlackScreenManager screen;
    public DayManager dayManager;
    public DayNightCycle dnc;
    [SerializeField]
    private Transform tpTransform;
    private AudioManager audioManager;
    private void Start()
    {
        screen = FindObjectOfType<BlackScreenManager>();
        dayManager = FindObjectOfType<DayManager>();
        dnc = FindObjectOfType<DayNightCycle>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public override void InteractWith(PlayerController pc)
    {
        if (enabled == false)
        {
            return;
        }

        pc.SetLockMovement(true);
        pc.gameObject.transform.position = tpTransform.position;
        pc.gameObject.transform.rotation = tpTransform.rotation;
        audioManager.interactablesAudio.SleepAudio(this.gameObject);
        //screen.Fade(true);
        StopCoroutine(ChangeDay(pc));
        StartCoroutine(ChangeDay(pc));
    }

    public IEnumerator ChangeDay(PlayerController pc)
    {
        pc.player.PlaySleepAnimation();
        yield return new WaitForSeconds(.8f);
        screen.Fade(true, 1);
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        dnc.Invoke();
        pc.player.RefillEnergy();
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        yield return new WaitForSeconds(1);
        pc.SetLockMovement(false);
    }
}
