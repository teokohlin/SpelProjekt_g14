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

    public float textFadeMultiplier = 2;
    [Space] 
    public Sprite[] sprites;

    public string[] strings;
    public BlackScreenManager blackScreen;
    public MusicManager musicManager;
    
    [Space] 
    public GameObject textBox;
    public TextMeshProUGUI text;
    public Image image;
    [SerializeField]
    private int index = 0;
    private bool justSwapped = false;

    private void Start()
    {
        justSwapped = true;

        StartCoroutine(FirstImage());
        //StartCoroutine(NextImage());
    }

    void Update()
    {
        if (Input.anyKey)
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
            musicManager.ProgressIntro(index);
            StartCoroutine(NextImage());


        }
    }

    /*
    private void NextImageVoid()
    {
        image.sprite = sprites[index];
        text.text = strings[index];




        StartCoroutine(Delay());
        

    } 
    
    */

    IEnumerator NextImage()
    {

        blackScreen.Fade(true);
        yield return new WaitForSeconds(1 / blackScreen.fadeSpeed);
        
        
        
        
        image.sprite = sprites[index];
        text.text = strings[index];
        //textBox.SetActive(false);
        textBox.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        text.color = new Color(0, 0, 0, 0);
        index++;


        yield return new WaitForSeconds(timeUntilText);
        //textBox.SetActive(true);
        StartCoroutine(FadeText());

        
    }

    IEnumerator FirstImage()
    {
        image.sprite = sprites[index];
        text.text = strings[index];
        //textBox.SetActive(false);
        textBox.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        text.color = new Color(0, 0, 0, 0);
        index++;
        
        yield return new WaitForSeconds(timeUntilText);
        //textBox.SetActive(true);
        StartCoroutine(FadeText());
        

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(minimumWaitTime);
        justSwapped = false;
    }

    IEnumerator FadeText()
    {
        Image txtBoxImage = textBox.GetComponent<Image>();

        while (txtBoxImage.color.a < 1)
        {
            //Bilden
            float a = txtBoxImage.color.a;
            a += Time.deltaTime * textFadeMultiplier;
            txtBoxImage.color = new Color(1, 1, 1, a);

            //Texten
            float ta = text.color.a;
            ta += Time.deltaTime * textFadeMultiplier;
            text.color = new Color(0, 0, 0, ta);
            
            
            yield return new WaitForEndOfFrame();

        }
        
        StopCoroutine(Delay());
        StartCoroutine(Delay());
    }
}
