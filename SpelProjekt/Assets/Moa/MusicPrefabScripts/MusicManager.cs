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
        public StudioEventEmitter musicMain;
        public StudioEventEmitter musicMenu;
    }
    public Emitters eventEmitters;

    [EventRef]
    public string gameOverStinger;
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
    public void PlayMusic(string eventName)
    {
        switch (eventName)
        {
            case "musicMain":
                if (!eventEmitters.musicMain.IsActive)

                {
                    eventEmitters.musicMain.Play();
                }
                break;

            case "musicMenu":
               if (!eventEmitters.musicMenu.IsActive)

                {
                    eventEmitters.musicMenu.Play();
                }
                break;
        }
    }
    public void StopMusic(string eventName)
    {
        switch (eventName)
        {
            case "musicMain":
                eventEmitters.musicMain.Stop();
                break;
            case "musicBoss":
                eventEmitters.musicMenu.Stop();
                break;
          
        }
    }
    public void SetParameter(string eventName)
    {
    }


}
