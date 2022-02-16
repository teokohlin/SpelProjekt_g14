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

    [Space]
    public GameObject questButtonPrefab;

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
            ToggleQuestPanel();
        }
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

        panelOpen = false;
        questPanel.SetActive(panelOpen);

        windowOpen = true;

        questWindow.SetActive(true);
        questTitle.text = kvist.title;
        questDescription.text = kvist.description;
        rewardImage.sprite = kvist.rewardSprite;
        rewardAmount.text = kvist.rewardAmount.ToString();
        progressText.text = kvist.goal.currentAmount.ToString() +  "/" + kvist.goal.requiredAmount.ToString();
        requiredResourceIMG.sprite = kvist.goal.requiredResourceSprite;


    }

    public void AddQuest(Quest quest)
    {
        player.quests.Add(quest);
        quest.isActive = true;
        GameObject panelButton = Instantiate(questButtonPrefab, questPanel.transform.position, Quaternion.identity, questPanel.transform);
        panelButton.GetComponent<QuestButton>().quest = quest;
    }
}
