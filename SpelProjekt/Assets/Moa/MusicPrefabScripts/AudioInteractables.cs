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
    }

    private AudioManager audioMananger;



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
                    audioMananger.interactablesAudio.PickUpHealthAudio(audioObject);
                    break;
                case AudioInteractableType.DoorOpen:
                    audioMananger.interactablesAudio.DoorOpenAudio(audioObject);
                    break;
                case AudioInteractableType.DestructableBox:
                    audioMananger.interactablesAudio.DestructableBoxAudio(audioObject);
                    break;
                case AudioInteractableType.Switches:
                    audioMananger.interactablesAudio.SwitchesAudio(audioObject);
                    break;
            }
        }
    }

    public void DestructableBoxAudioPlay()
    {
        audioMananger.interactablesAudio.DestructableBoxAudio(audioObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioMananger = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
