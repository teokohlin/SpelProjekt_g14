using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNapp : MonoBehaviour
{
    public GameObject buildWindow;
    private bool isOpen;

    public void Start()
    {
        isOpen = false;
    }

    //Toggles build window when button is clicked
    public void KnappKlickad()
    {
        isOpen = !isOpen;
        buildWindow.SetActive(isOpen);

    }

    //Toggles build window when 'e' is pressed
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KnappKlickad();
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
