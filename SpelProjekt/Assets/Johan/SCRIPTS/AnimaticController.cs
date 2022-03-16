using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimaticController : MonoBehaviour
{

    public float minimumWaitTime = 2f;
    [Space] 
    public Sprite[] sprites;

    public string[] strings;
    
    [Space]
    public TextMeshProUGUI text;
    public Image image;
    
    private int index = 0;
    private bool justSwapped = false;

    private void Start()
    {
        justSwapped = true;
        NextImage();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (justSwapped)
            {
                return;
            }
            
            if (index > sprites.Length - 1 )
            {
                SceneManager.LoadScene("Main scene");
            }
            


            justSwapped = true;
            
            NextImage();


        }
    }

    private void NextImage()
    {
        if (index > sprites.Length - 1)
        {
            return;
        }
        
        image.sprite = sprites[index];
        text.text = strings[index];

        index++;

        StopAllCoroutines();
        StartCoroutine(Delay());
        

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(minimumWaitTime);
        justSwapped = false;
    }
}
