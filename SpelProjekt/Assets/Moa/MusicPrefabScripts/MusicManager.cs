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
        public StudioEventEmitter ambiance;
        public StudioEventEmitter musicStart;
    }

    public Emitters eventEmitters;


    
    [EventRef]
    public string progressionStinger;
    [EventRef]
    public string menuStartGame;
    [ParamRef]
    public string timeOfDayParam;
    [ParamRef]
    public string progress;

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
            case "ambiance":
                if (!eventEmitters.ambiance.IsActive)

                {
                    eventEmitters.ambiance.Play();
                }
                break;
            case "musicStart":
                if (!eventEmitters.musicStart.IsActive)

                {
                    eventEmitters.musicStart.Play();
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
            case "musicMenu":
                eventEmitters.musicMenu.Stop();
                break;
            case "ambiance":
                eventEmitters.ambiance.Stop();
                break;
            case "musicStart":
                eventEmitters.musicStart.Stop();
                break;
        }
    }

    public void SetParameter(string eventName)
    {

    }
    public void PlayMenuStart()
    {
        RuntimeManager.PlayOneShot(menuStartGame);
    }

    public void PlayProgression()
    {
        if (progressionStinger == "")
            return;
        RuntimeManager.PlayOneShot(progressionStinger);
    }

    public void MusicTimeOfDay(float timeOfDay)
    {
        RuntimeManager.StudioSystem.setParameterByName(timeOfDayParam, timeOfDay);
    }

    public void ProgressIntro(int stage)
    {
        RuntimeManager.StudioSystem.setParameterByName(progress, stage);
    }


}
