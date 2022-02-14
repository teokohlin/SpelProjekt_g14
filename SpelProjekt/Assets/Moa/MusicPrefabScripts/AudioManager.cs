using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMOD.Studio;
using FMODUnity;

public class AudioMananger : MonoBehaviour
{

    [Serializable]
    public class InteractablesAudio
    {

        [Header("The Monsters")]

        [EventRef]
        public string doorOpenEvent;
        [EventRef]
        public string pickupHealthEvent;
        [EventRef]
        public string destructableBoxEvent;
        [EventRef]
        public string switchesEvent;
        [EventRef]
        public string menuHoverEvent;
        [EventRef]
        public string menuPressEvent;



        public void DoorOpenAudio(GameObject doorObject)
        {
            RuntimeManager.PlayOneShotAttached(doorOpenEvent.ToString(), doorObject);
        }

        public void PickUpHealthAudio(GameObject pickUpHealthObject)
        {
            RuntimeManager.PlayOneShotAttached(pickupHealthEvent.ToString(), pickUpHealthObject);
        }

        public void DestructableBoxAudio(GameObject destructableBoxObject)
        {
            RuntimeManager.PlayOneShotAttached(destructableBoxEvent.ToString(), destructableBoxObject);
        }

        public void SwitchesAudio(GameObject switchesObject)
        {
            RuntimeManager.PlayOneShotAttached(switchesEvent.ToString(), switchesObject);
        }

        public void MenuHoverAudio(GameObject menuhoverObject)
        {
            RuntimeManager.PlayOneShotAttached(menuHoverEvent.ToString(), menuhoverObject);
        }

        public void MenuPressAudio(GameObject menupressObject)
        {
            RuntimeManager.PlayOneShotAttached(menuPressEvent.ToString(), menupressObject);
        }


    }


    [Serializable]
    public class PlayerAudio
    {

        [EventRef]
        public string playerFootstepEvent;
        private EventInstance playerFootstepInstance;
        [EventRef]
        public string playerDamageEvent;
        private EventInstance playerDamageInstance;

        public void PlayerDamageAudio(GameObject damageObject)
        {
            playerDamageInstance = RuntimeManager.CreateInstance(playerDamageEvent);

            RuntimeManager.AttachInstanceToGameObject(playerDamageInstance, damageObject.transform, damageObject.GetComponent<Rigidbody>());

            playerDamageInstance.start();

            playerDamageInstance.release();
        }

        public void PlayerFootstepAudio(GameObject footstepObject, string surface)
        {

            playerFootstepInstance = RuntimeManager.CreateInstance(playerFootstepEvent);

            RuntimeManager.AttachInstanceToGameObject(playerFootstepInstance, footstepObject.transform, footstepObject.GetComponent<Rigidbody>());
            switch (surface)
            {
                case "Water":
                    playerFootstepInstance.setParameterByName("Surface", 0f);
                    break;
                case "Ground":
                    playerFootstepInstance.setParameterByName("Surface", 1f);
                    break;
                case "Carpet":
                    playerFootstepInstance.setParameterByName("Surface", 2f);
                    break;
                case "Wood":
                    playerFootstepInstance.setParameterByName("Surface", 3f);
                    break;

            }

            playerFootstepInstance.start();

            playerFootstepInstance.release();
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
