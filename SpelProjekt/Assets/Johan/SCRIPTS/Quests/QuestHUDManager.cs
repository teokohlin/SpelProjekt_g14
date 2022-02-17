using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestHUDManager : MonoBehaviour
{
    private Player player;

    public GameObject questWindow;
    public GameObject questPanel;

    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public Image rewardImage;
    public TextMeshProUGUI rewardAmount;
    public TextMeshProUGUI progressText;
    public Image requiredResourceIMG;
    private Quest currentQuest;

    [Space]
    public GameObject questButtonPrefab;
    private List<GameObject> questButtons = new List<GameObject>();

    bool panelOpen;
    bool windowOpen;

    private void Start()
    {
        player = FindObjectOfType<Player>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuestsButtonClicked();
        }

        if (currentQuest == null)
        {
            return;
        }
        questTitle.text = currentQuest.title;
        questDescription.text = currentQuest.description;
        rewardImage.sprite = currentQuest.rewardSprite;
        rewardAmount.text = currentQuest.rewardAmount.ToString();
        progressText.text = currentQuest.goal.currentAmount.ToString() +  "/" + currentQuest.goal.requiredAmount.ToString();
        requiredResourceIMG.sprite = currentQuest.goal.requiredResourceSprite;

    }

    public void ToggleQuestPanel()
    {
        if (panelOpen)
        {
            panelOpen = false;
            questPanel.SetActive(panelOpen);
            windowOpen = true;
            questWindow.SetActive(windowOpen);
        }
        else
        {
            panelOpen = true;
            questPanel.SetActive(panelOpen);
            windowOpen = false;
            questWindow.SetActive(windowOpen);
        }
    }
    public void QuestsButtonClicked()
    {
        if (panelOpen || windowOpen)
        {
            CloseQuestAll();
        }
        else
        {
            OpenPanelOnly();
        }
    }
    public void CloseQuestAll()
    {
        panelOpen = false;
        questPanel.SetActive(panelOpen);
        windowOpen = false;
        questWindow.SetActive(windowOpen);
    }
    public void OpenPanelOnly()
    {
        panelOpen = true;
        questPanel.SetActive(panelOpen);
    }

    public void OpenQuestWindow(Quest kvist)
    {
        currentQuest = kvist;
        panelOpen = false;
        questPanel.SetActive(panelOpen);

        windowOpen = true;

        questWindow.SetActive(true);



    }

    public void AddQuest(Quest quest, QuestGiver questGiver)
    {
        //player.quests.Add(quest);
        quest.isActive = true;
        quest.Init();
        quest.questGiver = questGiver;
        GameObject panelButton = Instantiate(questButtonPrefab, questPanel.transform.position, Quaternion.identity, questPanel.transform);
        panelButton.GetComponent<QuestButton>().quest = quest;      
        questButtons.Add(panelButton);
    }
    public void RemoveQuest(Quest quest)
    {
        windowOpen = false;
        questWindow.SetActive(windowOpen);
        quest.isActive = false;
        quest.questGiver.QuestFinished();
        foreach (var button in questButtons)
        {
            if (button.GetComponent<QuestButton>().quest.isActive == false)
            {
                Destroy(button);
                //tror error dyker upp i denna foreach någonstans
            }
        }
    }


    void UpdateQuestWindow(Quest quest)
    {
        questTitle.text = quest.title;
        questDescription.text = quest.description;
        rewardImage.sprite = quest.rewardSprite;
        if (quest.rewardAmount == 0)
        {
            rewardAmount.text = " ";
        }
        else
        {
            rewardAmount.text = quest.rewardAmount.ToString();
        }
        progressText.text = quest.goal.currentAmount.ToString() +  "/" + quest.goal.requiredAmount.ToString();
        requiredResourceIMG.sprite = quest.goal.requiredResourceSprite;
    }
}
