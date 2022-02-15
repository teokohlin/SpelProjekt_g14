using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestButton : MonoBehaviour
{
    public QuestHUDManager questHUD;
    [HideInInspector]
    public Quest quest;

    public TextMeshProUGUI buttonText;
    private void Start()
    {
        questHUD = GetComponentInParent<QuestHUDManager>();
        buttonText.text = quest.title;
    }

    public void ButtonPressed()
    {
        questHUD.OpenQuestWindow(quest);
    }

}
