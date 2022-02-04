using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{


    //Synligt i Fmod
    [Header("Player")]

    [EventRef]
    public string playerFootsteps;
    [EventRef]
    public string playerJump;
    [EventRef]
    public string playerLand;
    [EventRef]
    public string playerHurt;


    //Ljud Monster
    [Header("The Monsters")]

    [EventRef]
    public string MonsterA;
    [EventRef]
    public string MonsterB;
    [EventRef]
    public string MonsterC;
    [EventRef]
    public string MonsterD;
    [EventRef]
    public string MonsterE;
    [EventRef]
    public string MonsterF;

    //Materiella ljud
    [EventRef]
    public string doorSwitch;


    [Header("UI")]
    [FMODUnity.EventRef]
    public string menuClick;
    [FMODUnity.EventRef]
    public string menuStartGame;



 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }






    public void PlayDoorSwitch(GameObject switchObject)
    {
        RuntimeManager.PlayOneShotAttached(doorSwitch, switchObject);
        Debug.Log("Played DoorSwitch");
    }


}
