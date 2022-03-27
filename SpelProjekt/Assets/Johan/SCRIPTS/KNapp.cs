using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNapp : MonoBehaviour
{
    public GameObject background;
    private bool isOpen;
    public void Start()
    {
        isOpen = false;
    }

    //Toggles build menu when button is pressed
    public void KnappKlickad()
    {
        isOpen = !isOpen;
        background.SetActive(isOpen);
    }
    public void Exit()
    {
        Application.Quit();
    }
    //Checks if e is pressed and toggles build menu if it is
    public void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            KnappKlickad();
        }
    }
}
