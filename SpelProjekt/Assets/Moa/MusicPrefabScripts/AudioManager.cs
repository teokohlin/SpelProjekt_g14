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


    //ljud
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









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
