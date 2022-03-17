using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimaticController : MonoBehaviour
{

    public float timeUntilText = 3f;

    public float minimumWaitTime = 2f;
    [Space] 
    public Sprite[] sprites;

    public string[] strings;
    public BlackScreenManager blackScreen;

    [Space] 
    public GameObject textBox;
    public TextMeshProUGUI text;
    public Image image;
    
    private int index = 0;
    private bool justSwapped = false;

    private void Start()
    {
        justSwapped = true;
        
        
        //StartCoroutine(NextImage());
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
            
            if (index > sprites.Length - 1)
            {
                return;
            }
            StartCoroutine(NextImage());


        }
    }

    private void NextImageVoid()
    {
        image.sprite = sprites[index];
        text.text = strings




        StopAllCoroutines();
        StartCoroutine(Delay());
        

    } 

    IEnumerator NextImage()
    {
        blackScreen.Fade(true);
        yield return new WaitForSeconds(1 / blackScreen.fadeSpeed);
        
        image.sprite = sprites[index];
        text.text = strings[index];
        textBox.SetActive(false);
        index++;


        yield return new WaitForSeconds(timeUntilText);
        textBox.SetActive(true);

        
        StopCoroutine(Delay());
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(minimumWaitTime);
        justSwapped = false;
    }
}
