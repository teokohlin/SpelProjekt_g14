using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public RectTransform infoWindow;
    public Image itemImage;
    public Sprite[] itemSprites;
    public static Action<string, Vector2, int> OnMouseHover;
    public static Action OnMouseLoseFocus;
    
    private void OnEnable()
    {
        OnMouseHover += ShowInfo;
        OnMouseLoseFocus += HideInfo;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowInfo;
        OnMouseLoseFocus -= HideInfo;    }

    void Start()
    {
        HideInfo();
    }

    public void ChangeSprite(int num)
    {
        for (int i = 0; i < itemSprites.Length; i++)
        {
            if(i == num)
            {
                itemImage.sprite = itemSprites[i];
            }
        }
    }

    private void ShowInfo(string info, Vector2 mousePos, int index)
    {
        
        infoText.text = info;
        
        infoWindow.sizeDelta = new Vector2(infoText.preferredWidth > 200 ? 200 :itemImage.preferredWidth > 200 ? 200: infoText.preferredWidth,
            infoText.preferredHeight + itemImage.preferredHeight / 2);
        
        infoWindow.gameObject.SetActive(true);
        
        infoWindow.transform.position = new Vector2(mousePos.x, mousePos.y + infoWindow.sizeDelta.y / 3);
        
        ChangeSprite(index);
        itemImage.gameObject.SetActive(true);
    }
    
    private void HideInfo()
    {
        infoText.text = default;
        infoWindow.gameObject.SetActive(false);
        itemImage.gameObject.SetActive(false);
    }
}
