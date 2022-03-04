using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public QuestHUDManager questHUD;
    [HideInInspector]
    public Quest quest;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI progressText;
    public Image requiredResourceImage;
    public GameObject[] progressObjects;

    private void Start()
    {
        questHUD = GetComponentInParent<QuestHUDManager>();
        titleText.text = quest.title;
        for (int i = 0; i < quest.goals.Length; i++)
        {
            //progressObjects
        }
        progressText.text = quest.goals[0].currentAmount.ToString() +  "/" + quest.goals[0].requiredAmount.ToString();
        requiredResourceImage.sprite = quest.goals[0].requiredResourceSprite;

        //if ()
        //{

        //}
    }
    private void Update()
    {
        titleText.text = quest.title;
        progressText.text = quest.goals[0].currentAmount.ToString() +  "/" + quest.goals[0].requiredAmount.ToString();
        requiredResourceImage.sprite = quest.goals[0].requiredResourceSprite;
        if (quest.goals[0].requiredResourceSprite == null)
        {
            requiredResourceImage.gameObject.SetActive(false);
        }
        else
        {
            requiredResourceImage.gameObject.SetActive(true);
        }


    }

    public void ButtonPressed()
    {
        questHUD.OpenQuestWindow(quest);
    }

}
