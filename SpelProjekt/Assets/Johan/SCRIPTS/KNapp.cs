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
    public void KnappKlickad()
    {
        Debug.Log("klick");
        background.SetActive(isOpen);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
