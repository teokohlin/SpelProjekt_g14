using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.Tilemaps;

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

    [Space(10)]
    [HideInInspector]
    public TileBase surface01;
    [HideInInspector]
    public TileBase surface02;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayFootstep(TileBase tileBase)
    {
        if (playerFootsteps == "")
        {
            Debug.LogWarning("Fmod event not found: playerFootsteps");
            return;
        }

        FMOD.Studio.EventInstance footstepInstance;

        if (tileBase == surface01)
        {
            footstepInstance = RuntimeManager.CreateInstance(playerFootsteps);
            footstepInstance.setParameterByName("Surface", 0.0f);
            footstepInstance.start();
            //Debug.Log("Played Footstep - surface: 01");
        }
        else if (tileBase == surface02)
        {
            footstepInstance = RuntimeManager.CreateInstance(playerFootsteps);
            footstepInstance.setParameterByName("Surface", 1.0f);
            footstepInstance.start();
            //Debug.Log("Played Footstep - surface: 02");
        }
        else
        {
            footstepInstance = RuntimeManager.CreateInstance(playerFootsteps);
            footstepInstance.setParameterByName("Surface", 0.0f);
            footstepInstance.start();
            //Debug.Log("Played Footstep - surface: Other");
        }
    }

    public void PlayDoorSwitch(GameObject switchObject)
    {
        RuntimeManager.PlayOneShotAttached(doorSwitch, switchObject);
        Debug.Log("Played DoorSwitch");
    }


}
