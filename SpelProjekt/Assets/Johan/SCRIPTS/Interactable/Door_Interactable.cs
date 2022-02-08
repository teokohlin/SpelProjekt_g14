using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interactable : Interactable
{
    private GameManager gm;
    //public string targetSceneName;
    public Vector3 targetPosition = Vector3.one;
    public Transform spawnpoint;
    public Transform camera;
    private void Start()
    {
        //gm = FindObjectOfType<GameManager>();
    }
    public override void InteractWith(PlayerController pc)
    {
        //base.InteractWith();

        //refill energy
        //pc.player.RefillEnergy();
        //GetComponent<DialogueTrigger>().TriggerDialogue();

        //gm.ChangeScene(targetSceneName, targetPosition);

        pc.gameObject.transform.position = spawnpoint.position;
        camera.position = spawnpoint.position + camera.GetComponent<CameraFollow>().offset;
    }
}
