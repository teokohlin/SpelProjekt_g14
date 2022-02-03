using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    [SerializeField] 
    private RectTransform border;

    private float xvalue = -90.5f;
    private Vector3 currentposition;
    void Update()
    {
        currentposition = new Vector3(xvalue, -192, 0);
        border.localPosition = currentposition;

        Debug.Log(currentposition);

        // 1: posx -90.5f 2: posx  -43 3: posx 4 4: posx 50 5: posx 97
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("Pressed 1");
            xvalue = -90.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("Pressed 2");
            xvalue = -43;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("Pressed 3");
            xvalue = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log("Pressed 4");
            xvalue = 50;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log("Pressed 5");
            xvalue = 97;
        }
        
        
    }
}
