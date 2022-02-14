using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string infoToShow;
    public string titelToShow;
    public int toolIndex;
    private float timer = 0.5f;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
    }

    private void ShowDesciption()
    {
        HoverTipManager.OnMouseHover(infoToShow, titelToShow, Input.mousePosition, toolIndex);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timer);
        
        ShowDesciption();
    }
}
