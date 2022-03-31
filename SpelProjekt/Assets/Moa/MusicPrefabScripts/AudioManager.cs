using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

    [Serializable]
    public class InteractablesAudio
    {

        [Header("The Monsters")]

        [EventRef]
        public string doorOpenEvent;
        [EventRef]
        public string menuPressEvent;
        [EventRef]
        public string stoneEvent;
        [EventRef]
        public string treeEvent;
        [EventRef]
        public string pickupEvent;
        [EventRef]
        public string seedsEvent;
        [EventRef]
        public string useWaterEvent;
        [EventRef]
        public string waterRefillEvent;
        [EventRef]
        public string pickBerriesEvent;
        [EventRef]
        public string hoeEvent;
        [EventRef]
        public string schytheEvent;
        [EventRef]
        public string sleepEvent;


        public void SleepAudio(GameObject sleepObject)
        {
            RuntimeManager.PlayOneShotAttached(sleepEvent.ToString(), sleepObject);
        }
        public void useSchytheAudio(GameObject schytheObject)
        {
            RuntimeManager.PlayOneShotAttached(schytheEvent.ToString(), schytheObject);
        }
        public void useHoeAudio(GameObject hoeObject)
        {
            RuntimeManager.PlayOneShotAttached(hoeEvent.ToString(), hoeObject);
        }
        public void PickBerriesAudio(GameObject berriesObject)
        {
            RuntimeManager.PlayOneShotAttached(pickBerriesEvent.ToString(), berriesObject);
        }
        public void WaterRefillAudio(GameObject waterObject)
        {
            RuntimeManager.PlayOneShotAttached(waterRefillEvent.ToString(), waterObject);
        }
        public void UseWaterAudio(GameObject waterObject)
        {
            RuntimeManager.PlayOneShotAttached(useWaterEvent.ToString(), waterObject);
        }
        public void SeedsAudio(GameObject seedsObject)
        {
            RuntimeManager.PlayOneShotAttached(seedsEvent.ToString(), seedsObject);
        }







        public void DoorOpenAudio(GameObject doorObject)
        {
            RuntimeManager.PlayOneShotAttached(doorOpenEvent.ToString(), doorObject);
        }

        public void MenuPressAudio(GameObject menupressObject)
        {
            RuntimeManager.PlayOneShotAttached(menuPressEvent.ToString(), menupressObject);
        }
        public void StoneAudio(GameObject stoneObject)
        {
            RuntimeManager.PlayOneShotAttached(stoneEvent.ToString(), stoneObject);
        }

        public void TreeAudio(GameObject treeObject)
        {
            RuntimeManager.PlayOneShotAttached(treeEvent.ToString(), treeObject);
        }
        public void PickupAudio(GameObject pickupObject)
        {
            RuntimeManager.PlayOneShotAttached(pickupEvent.ToString(), pickupObject);
        }

    }



    [Serializable]
    public class PlayerAudio
    {

        [EventRef]
        public string playerFootstepEvent;
        private EventInstance playerFootstepInstance;


        public void PlayerFootstepAudio(GameObject footstepObject, string surface)
        {

            playerFootstepInstance = RuntimeManager.CreateInstance(playerFootstepEvent);

            RuntimeManager.AttachInstanceToGameObject(playerFootstepInstance, footstepObject.transform, footstepObject.GetComponent<Rigidbody>());
            switch (surface)
            {
                case "Carpet":
                    playerFootstepInstance.setParameterByName("Surface", 0f);
                    break;
                case "Grass":
                    playerFootstepInstance.setParameterByName("Surface", 1f);
                    break;
                case "Wood":
                    playerFootstepInstance.setParameterByName("Surface", 2f);
                    break;
                case "Water":
                    playerFootstepInstance.setParameterByName("Surface", 3f);
                    break;

            }

            playerFootstepInstance.start();

           // playerFootstepInstance.release();
        }

    }
    [Serializable]
    public class EnemyAudio
    {

        [EventRef]
        public string enemyFootstepEvent;

        private EventInstance enemyFootstepInstance;

        public void EnemyFootstepAudio(GameObject footstepObject)
        {
            enemyFootstepInstance = RuntimeManager.CreateInstance(enemyFootstepEvent);

            RuntimeManager.AttachInstanceToGameObject(enemyFootstepInstance, footstepObject.transform, footstepObject.GetComponent<Rigidbody>());

            enemyFootstepInstance.start();

            enemyFootstepInstance.release();
        }
    }

    public InteractablesAudio interactablesAudio;
    public PlayerAudio playerAudio;
    public EnemyAudio enemyAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
