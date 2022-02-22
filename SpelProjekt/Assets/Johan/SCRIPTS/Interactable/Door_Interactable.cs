using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Interactable : Interactable
{
    private GameManager gm;
    //public string targetSceneName;
    public Vector3 targetPosition = Vector3.one;
    public Transform spawnpoint;
    public Transform camera;
    private BlackScreenManager screen;

    private void Start()
    {
        screen = FindObjectOfType<BlackScreenManager>();
    }

    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith();

        //refill energy
        //pc.player.RefillEnergy();
        //GetComponent<DialogueTrigger>().TriggerDialogue();
        
        //gm.ChangeScene(targetSceneName, targetPosition);

        screen.Fade(true);
        pc.SetLockMovement(true);
        StartCoroutine(Teleport(pc));
    }

    public IEnumerator Teleport(PlayerController pc)
    {
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        pc.gameObject.transform.position = spawnpoint.position;
        camera.position = spawnpoint.position + camera.GetComponent<CameraFollow>().offset;
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        pc.SetLockMovement(false);
    }
}
