using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestHUDManager : MonoBehaviour
{
    public Player player;

    public GameObject questWindow;
    public GameObject questPanel;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public Image rewardImage;
    public TextMeshProUGUI rewardAmount;

    public GameObject questButtonPrefab;

    bool panelOpen;
    bool windowOpen;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        Instantiate(questButtonPrefab, questPanel.transform.position, Quaternion.identity, questPanel.transform);

    }
    public void OpenCloseQuestPanel()
    {
        if (panelOpen)
        {
            panelOpen = false;
            questPanel.SetActive(panelOpen);
            questWindow.SetActive(false);
        }
        else
        {
            panelOpen = true;
            questPanel.SetActive(panelOpen);
        }
    }
    public void OpenQuestWindow(Quest kvist)
    {
        if (windowOpen)
        {
            windowOpen = false;
            questWindow.SetActive(windowOpen);
        }
        else
        {
            windowOpen = true;

            questWindow.SetActive(true);
            questTitle.text = kvist.title;
            questDescription.text = kvist.description;
            rewardImage.sprite = kvist.rewardSprite;
            rewardAmount.text = kvist.rewardAmount.ToString();

        }
        
        //questWindow.SetActive(true);
        //questTitle.text = player.quests[questIndex].title;
        //questDescription.text = player.quests[questIndex].description;
        //rewardImage.sprite = player.quests[questIndex].rewardSprite;
        //rewardAmount.text = player.quests[questIndex].rewardAmount.ToString();

    }

    public void AddQuest(Quest quest)
    {
        player.quests.Add(quest);

        Instantiate(questButtonPrefab, questPanel.transform.position, Quaternion.identity, questPanel.transform);
    }
}
