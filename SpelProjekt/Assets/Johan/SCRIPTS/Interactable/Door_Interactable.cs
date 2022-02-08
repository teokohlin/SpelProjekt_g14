using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interactable : Interactable
{
    private GameManager gm;
    public string targetSceneName;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith();

        //refill energy
        //pc.player.RefillEnergy();
        //GetComponent<DialogueTrigger>().TriggerDialogue();

        gm.ChangeScene(targetSceneName, Vector3.one);
    }
}
