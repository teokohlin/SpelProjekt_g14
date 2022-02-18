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
                case AudioInteractableType.PickUpHealth:
                    audioManager.interactablesAudio.PickUpHealthAudio(audioObject);
                    break;
                case AudioInteractableType.DoorOpen:
                    audioManager.interactablesAudio.DoorOpenAudio(audioObject);
                    break;
                case AudioInteractableType.DestructableBox:
                    audioManager.interactablesAudio.DestructableBoxAudio(audioObject);
                    break;
                case AudioInteractableType.Switches:
                    audioManager.interactablesAudio.SwitchesAudio(audioObject);
                    break;
                case AudioInteractableType.Stone:
                    audioManager.interactablesAudio.StoneAudio(audioObject);
                    break;
            }
        }
    }

    public void DestructableBoxAudioPlay()
    {
        audioManager.interactablesAudio.DestructableBoxAudio(audioObject);
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
