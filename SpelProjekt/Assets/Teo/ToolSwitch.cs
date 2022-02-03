using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{
    public int currentTool;
    [SerializeField] private Transform[] tools;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeTool(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeTool(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeTool(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            changeTool(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            changeTool(4);
        }
    }

    public void changeTool(int num)
    {
        currentTool = num;
        for (int i = 0; i < tools.Length; i++)
        {
            if (i == num)
            {
                tools[i].gameObject.SetActive(true);
            }
            else
            {
                tools[i].gameObject.SetActive(false);
            }
        }
    }
}