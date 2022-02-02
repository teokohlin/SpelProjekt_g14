using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MusicManager : MonoBehaviour
{
    [System.Serializable]
    public struct Emitters
    {
        public StudioEventEmitter music;
        public StudioEventEmitter musicBoss;
        public StudioEventEmitter ambiance;
    }
    public Emitters eventEmitters;


    [Header("Stingers")]

    [EventRef]
    public string progressionStinger;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
