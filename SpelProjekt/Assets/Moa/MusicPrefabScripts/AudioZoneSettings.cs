using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class AudioZoneSettings : MonoBehaviour
{

    public enum EventAction
    {
        None,
        Play,
        Stop,
        SetParameter
    }


    [System.Serializable]

    public struct EventStruct
    {
        public EventAction action;
        public string eventName;
        [Tooltip("Name of the Parameter in FMOD")]
        public string Parameter;
        public float parameterValue;
    }

    public EventStruct[] events;

    public bool destroyAfterUse = true;
    public string tagName;
    Collider player;
    private bool hasCollided = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == tagName)
        {
            for (int i = 0; i < events.Length; i++)
            {
                player = other;
                hasCollided = true;

                if (destroyAfterUse == true)
                {
                    GetComponent<BoxCollider>().enabled = false;
                }


                switch (events[i].action)
                {
                    case EventAction.None:
                        break;

                    case EventAction.Play:
                        Debug.Log("I should play a sound");
                        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().PlayMusic(events[i].eventName);
                        break;

                    case EventAction.Stop:
                        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().StopMusic(events[i].eventName);

                        break;
                    case EventAction.SetParameter:
                        GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>().SetParameter(events[i].eventName);

                        break;
                }
            }
        }
    }
}
