using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverTipManager : MonoBehaviour
{
    [SerializeField]
    private int borderWidth = 210;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI titelText;
    public RectTransform infoWindow;
    public Image itemImage;
    public Image border;
    public Sprite[] itemSprites;
    public static Action<string, string, Vector2, int> OnMouseHover;
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

    private void ShowInfo(string info, string titel, Vector2 pos, int index)
    {
        
        infoText.text = info;
        titelText.text = titel;
        
        infoWindow.sizeDelta = new Vector2(infoText.preferredWidth > borderWidth ? borderWidth : itemImage.preferredWidth > borderWidth ? borderWidth: 
            titelText.preferredWidth > borderWidth ? borderWidth : infoText.preferredWidth,
            infoText.preferredHeight + titelText.preferredHeight + itemImage.preferredHeight / 2);
        
        infoWindow.gameObject.SetActive(true);
        
        //infoWindow.transform.position = new Vector2(mousePos.x, mousePos.y + infoWindow.sizeDelta.y / 2);
        infoWindow.transform.position = new Vector2(pos.x, pos.y * 2);
        ChangeSprite(index);
        itemImage.gameObject.SetActive(true);
        border.gameObject.SetActive(true);
    }
    
    private void HideInfo()
    {
        infoText.text = default;
        titelText.text = default;
        infoWindow.gameObject.SetActive(false);
        itemImage.gameObject.SetActive(false);
        border.gameObject.SetActive(false);
    }
}
