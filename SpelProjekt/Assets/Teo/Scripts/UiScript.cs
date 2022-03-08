using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject PauseMenu;

    private bool pause;
    
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

    [Space] 
    [SerializeField]
    private int CabbageCount, CarrotCount, WheatCount;
    [SerializeField] 
    private int[] seedCountList = new int[3];
    private int SeedAmount;
    [Space]
    [SerializeField] 
    private TextMeshProUGUI wheatText, carrotText, cabbageText, seedText;
    [SerializeField] 
    private Sprite[] seedSprites;

    Vector3 axePos, pickaxePos, hoePos, seedsPos, watercanPos, scythePos;
    
    public UnityAction<int> SeedIndex;

    private void Start()
    {
        FindObjectOfType<ToolSwitch>().ToolSwitchIndex += SwitchTool;
        axePos = axe.anchoredPosition;
        pickaxePos = pickaxe.anchoredPosition;
        hoePos = hoe.anchoredPosition;
        seedsPos = seeds.anchoredPosition;
        watercanPos = watercan.anchoredPosition;    
        scythePos = scythe.anchoredPosition;
        seedCountList[0] = CabbageCount;
        seedCountList[1] = CarrotCount;
        seedCountList[2] = WheatCount;
        wheatText.text = WheatCount.ToString();
        carrotText.text = CarrotCount.ToString();
        cabbageText.text = CabbageCount.ToString();
        ChangeSeed(2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (pause)
            {
                case true:
                    PauseMenu.SetActive(false);
                    pause = false;
                    break;
                case false:
                    PauseMenu.SetActive(true);
                    pause = true;
                    break;
            }
        }
    //    Vector3 axePos = axe.anchoredPosition;
    //    Vector3 hoePos = hoe.anchoredPosition;
    //    Vector3 pickaxePos = pickaxe.anchoredPosition;
    //    Vector3 scythePos = scythe.anchoredPosition;
    //    Vector3 watercanPos = watercan.anchoredPosition;
    //    Vector3 seedsPos = seeds.anchoredPosition;
        
    //    // 1: posx -237 2: posx  -111 3: posx 12 4: posx 135 5: posx 258
        
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        //Debug.Log("Pressed 1");
    //        border.anchoredPosition = axePos;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        //Debug.Log("Pressed 2");
    //        border.anchoredPosition = pickaxePos;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        //Debug.Log("Pressed 3");
    //        border.anchoredPosition = hoePos;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        //Debug.Log("Pressed 4");
    //        border.anchoredPosition = seedsPos;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha5))
    //    {
    //        //Debug.Log("Pressed 5");
    //        border.anchoredPosition = watercanPos;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha6))
    //    {
    //        border.anchoredPosition = scythePos;
    //    }
        
    }

    public void ChangeSeed(int num)
    {
        for (int i = 0; i < seedSprites.Length; i++)
        {
            if (i == num)
            {
                seeds.GetComponent<Image>().sprite = seedSprites[i];
                SeedAmount = seedCountList[i];
                seedText.text = SeedAmount.ToString();
                SeedIndex?.Invoke(i);
            }
        }
    }
    void SwitchTool(int num)
    {
        switch (num)
        {
            case 0: border.anchoredPosition = axePos;
                break;
            case 1: border.anchoredPosition = pickaxePos;
                break;
            case 2: border.anchoredPosition = hoePos;
                break;
            case 3: border.anchoredPosition = seedsPos;
                break;
            case 4: border.anchoredPosition = watercanPos;
                break;
            case 5: border.anchoredPosition = scythePos;
                break;
            default:
                break;
        }
    }

}
