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

    private void Start()
    {
        questHUD = GetComponentInParent<QuestHUDManager>();
        titleText.text = quest.title;
        progressText.text = quest.goal.currentAmount.ToString() +  "/" + quest.goal.requiredAmount.ToString();
        requiredResourceImage.sprite = quest.goal.requiredResourceSprite;
    }
    private void Update()
    {
        titleText.text = quest.title;
        progressText.text = quest.goal.currentAmount.ToString() +  "/" + quest.goal.requiredAmount.ToString();
        requiredResourceImage.sprite = quest.goal.requiredResourceSprite;
    }

    public void ButtonPressed()
    {
        questHUD.OpenQuestWindow(quest);
    }

}
