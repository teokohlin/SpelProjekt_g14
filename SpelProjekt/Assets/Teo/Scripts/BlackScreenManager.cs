using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenManager : MonoBehaviour
{
   public GameObject blackScreen;
   public bool isBlack = false;
   [Range(0,2)]
   public float fadeSpeed = 0.9f;

   private float delay = 0;
   private void Start()
   {
      StartCoroutine(FadeBlackScreen(false));
   }


   public void Fade(bool isBlack, float delay = 0)
   {
      this.delay = delay;
      StopCoroutine(FadeBlackScreen());
      StartCoroutine(FadeBlackScreen(isBlack));
      this.isBlack = isBlack;
   }
   public IEnumerator FadeBlackScreen(bool fadeToBlack = true)
   {
      Color imageColor = blackScreen.GetComponent<Image>().color;
      float fadeAmount;

      if (fadeToBlack)
      {
         while (blackScreen.GetComponent<Image>().color.a < 1)
         {
            fadeAmount = imageColor.a + (fadeSpeed * Time.deltaTime);

            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = imageColor;
            //isBlack = true;
            yield return null;
         }

         yield return new WaitForSeconds(delay);
         StartCoroutine(FadeBlackScreen(false));
      }
      else
      {
         while (blackScreen.GetComponent<Image>().color.a > 0)
         {
            fadeAmount = imageColor.a - (fadeSpeed * Time.deltaTime);

            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
            blackScreen.GetComponent<Image>().color = imageColor;
            //isBlack = false;
            yield return null;
         }
      }
   }
}
