using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenManager : MonoBehaviour
{
   public GameObject blackScreen;

   public void Update()
   {
      
   }

   public IEnumerator FadeBlackScreen(bool fadeToBlack = true, int fadeSpeed = 5)
   {
      yield return new WaitForEndOfFrame();
   }
}
