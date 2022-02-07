using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    [SerializeField] 
    private RectTransform border;

    [SerializeField]
    private RectTransform axe;

    [SerializeField] 
    private RectTransform hoe;

    [SerializeField] 
    private RectTransform pickaxe;

    [SerializeField] 
    private RectTransform scythe;

    [SerializeField] 
    private RectTransform watercan;

    [SerializeField] 
    private RectTransform seeds;

    void Update()
    {
        Vector3 axePos = axe.anchoredPosition;
        Vector3 hoePos = hoe.anchoredPosition;
        Vector3 pickaxePos = pickaxe.anchoredPosition;
        Vector3 scythePos = scythe.anchoredPosition;
        Vector3 watercanPos = watercan.anchoredPosition;
        Vector3 seedsPos = seeds.anchoredPosition;
        
        // 1: posx -237 2: posx  -111 3: posx 12 4: posx 135 5: posx 258
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("Pressed 1");
            border.anchoredPosition = axePos;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("Pressed 2");
            border.anchoredPosition = pickaxePos;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("Pressed 3");
            border.anchoredPosition = hoePos;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log("Pressed 4");
            border.anchoredPosition = seedsPos;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log("Pressed 5");
            border.anchoredPosition = watercanPos;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            border.anchoredPosition = scythePos;
        }
        
    }
}
