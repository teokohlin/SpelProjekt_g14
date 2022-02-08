using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenManager : MonoBehaviour
{
    [SerializeField] 
    private Image image;

    private Color temp;
    
    private float fade;
    void Start()
    { 
        temp = image.color;
    }

    void FixedUpdate()
    {
        if (IsBlack())
        {
            temp.a -= 0.05f;
            image.color = temp;
        }
        else if (IsTransparent())
        {
            temp.a += 0.05f;
            image.color = temp;
        }
    }

    public bool IsBlack()
    {
        Debug.Log("Black");
        if (temp.a >= 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsTransparent()
    {
        Debug.Log("transparent");
        if (temp.a <= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
