using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    [SerializeField] 
    private RectTransform border;

    private float xvalue = -237;
    private Vector3 currentposition;
    void Update()
    {
        currentposition = new Vector3(xvalue, -478.5f, 0);
        border.localPosition = currentposition;

        Debug.Log(currentposition);

        // 1: posx -237 2: posx  -111 3: posx 12 4: posx 135 5: posx 258
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("Pressed 1");
            xvalue = -237;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("Pressed 2");
            xvalue = -111;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("Pressed 3");
            xvalue = 12;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log("Pressed 4");
            xvalue = 135;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log("Pressed 5");
            xvalue = 258;
        }
        
        
    }
}
