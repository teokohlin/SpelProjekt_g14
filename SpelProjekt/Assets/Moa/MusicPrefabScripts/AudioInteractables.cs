using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteractables : MonoBehaviour
{
    public enum AudioInteractableType
    {
        DoorOpen,
        PickUpHealth,
        DestructableBox,
        PressurePad,
        Switches,
        Stone,
        Tree,
        Pickup,
        Menu,
    }

    private AudioManager audioManager;



    public AudioInteractableType audioInteractableType;
    public GameObject audioObject;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ditt Error Meddelande");
            switch (audioInteractableType)
            {
                case AudioInteractableType.DoorOpen:
                    audioManager.interactablesAudio.DoorOpenAudio(audioObject);
                    break;
                case AudioInteractableType.Stone:
                    audioManager.interactablesAudio.StoneAudio(audioObject);
                    break;
                case AudioInteractableType.Tree:
                    audioManager.interactablesAudio.TreeAudio(audioObject);
                    break;
                case AudioInteractableType.Pickup:
                    audioManager.interactablesAudio.PickupAudio(audioObject);
                    break;
                case AudioInteractableType.Menu:
                    audioManager.interactablesAudio.MenuPressAudio(audioObject);
                    break;

            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
