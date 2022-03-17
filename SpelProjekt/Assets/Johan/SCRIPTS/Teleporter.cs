using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform spawnpoint;
    public Transform camera;
    
    
    private BlackScreenManager screen;
    
    private PlayerController pc;
    void Start()
    {
        screen = FindObjectOfType<BlackScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }
        if (other.tag == "Player")
        {
            pc = other.GetComponent<PlayerController>();
            
            
            screen.Fade(true);
            pc.SetLockMovement(true);
            StartCoroutine(Teleport(pc));

        }
    }
    
    public IEnumerator Teleport(PlayerController pc)
    {
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        pc.gameObject.transform.position = spawnpoint.position;
        pc.gameObject.transform.rotation = spawnpoint.rotation;
        camera.position = spawnpoint.position + camera.GetComponent<CameraFollow>().offset;
        yield return new WaitForSeconds(1 / screen.fadeSpeed);
        pc.SetLockMovement(false);
    }
}
