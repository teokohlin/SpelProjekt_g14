using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToolSwitch : MonoBehaviour
{
    public int currentTool;

    private Animator animator;
    //public bool seed;
    public int index;
    [SerializeField] private Transform[] tools;

    public UnityAction<int> ToolSwitchIndex;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeTool(0);
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeTool(1);
            index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeTool(2);            
            index = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeTool(3);
            index = 3;
            /*
           
            seed = true;
            for (int i = 0; i < tools.Length; i++)
            {
                tools[i].gameObject.SetActive(false);
            }
            */
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeTool(4);
            index = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            index = 5;
            ChangeTool(5);
        }


        if (Input.mouseScrollDelta.y > 0f)
        {
            index--;

            index = Mathf.Clamp(index,0,5);

            ChangeTool(index);
        }
        else if (Input.mouseScrollDelta.y < 0f)
        {
            index++;

            index = Mathf.Clamp(index,0,5);

            ChangeTool(index);
        }
        
    }

    public void ChangeTool(int num)
    {
        index = num;
        //seed = false;
        
        animator.SetTrigger("Change Tool");
        
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

        ToolSwitchIndex?.Invoke(num);
    }
}
