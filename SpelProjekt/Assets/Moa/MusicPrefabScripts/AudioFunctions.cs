using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject footstepPlayerPosition;

    private AudioManager audioMananger;

    void Awake()
    {

        audioMananger = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    public void FootstepAudioPlay()
    {
        RaycastHit hit;
        Physics.Raycast(footstepPlayerPosition.transform.position, Vector3.down, out hit, 5f);
        Debug.DrawRay(footstepPlayerPosition.transform.position, Vector3.down * 5f, Color.blue, 1f);
        audioMananger.playerAudio.PlayerFootstepAudio(footstepPlayerPosition, hit.collider.tag);
    }



}
