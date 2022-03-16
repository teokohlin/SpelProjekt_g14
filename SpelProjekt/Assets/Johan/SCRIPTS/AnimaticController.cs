using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimaticController : MonoBehaviour
{

    public float minimumWaitTime = 1f;
    [Space] 
    public Sprite[] sprites;

    public string[] strings;
    
    [Space]
    public TextMeshProUGUI text;
    public Image image;
    
    private int index = 1;
    private bool justSwapped = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (justSwapped)
            {
                return;
            }

            justSwapped = true;
            
            NextImage();


        }
    }

    private void NextImage()
    {
        image.sprite = sprites[index];
        text.text = strings[index];

        index++;

        StopAllCoroutines();
        StartCoroutine(Delay());
        
        if (index > sprites.Length - 1)
        {
            //Change scene to game, Winky face
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(minimumWaitTime);
        justSwapped = false;
    }
}
