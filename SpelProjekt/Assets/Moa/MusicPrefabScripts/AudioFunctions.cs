using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject footstepPlayerPosition;
    public GameObject landingObject;
    public GameObject meleeObject;
    public GameObject deathObject;
    public GameObject jumpObject;
    public GameObject damageObject;
    public GameObject hurtObject;
    public GameObject shootObject;

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
        Debug.Log("We Hit: " + hit.collider.tag);
        audioMananger.playerAudio.PlayerFootstepAudio(footstepPlayerPosition, hit.collider.tag);
    }



    public void DamageAudioPlay()
    {
        audioMananger.playerAudio.PlayerDamageAudio(hurtObject);
    }

}
