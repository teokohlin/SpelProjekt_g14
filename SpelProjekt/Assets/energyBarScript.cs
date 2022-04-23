using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class energyBarScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI energyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        energyCount.color = new Color32(207, 193, 56, 255);
        Debug.Log("hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        energyCount.color = new Color32(207, 193, 56, 0);
        Debug.Log("pointer exit");
    }
}
