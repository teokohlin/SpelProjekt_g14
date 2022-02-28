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
    public TextMeshProUGUI justRewardText;
    private Quest currentQuest;
    private MusicManager musicManager;

    [Space]
    public GameObject questButtonPrefab;
    private List<GameObject> questButtons = new List<GameObject>();

    bool panelOpen;
    bool windowOpen;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        musicManager = FindObjectOfType<MusicManager>();

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
        UpdateQuestWindow(currentQuest);

        //questTitle.text = currentQuest.title;
        //questDescription.text = currentQuest.description;
        //rewardImage.sprite = currentQuest.rewardSprite;
        //rewardAmount.text = currentQuest.rewardAmount.ToString();
        //progressText.text = currentQuest.goal.currentAmount.ToString() + "/" + currentQuest.goal.requiredAmount.ToString();
        //requiredResourceIMG.sprite = currentQuest.goal.requiredResourceSprite;

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

        UpdateQuestWindow(currentQuest);

        //questTitle.text = kvist.title;
        //questDescription.text = kvist.description;
        //rewardImage.sprite = kvist.rewardSprite;
        //if (kvist.rewardAmount == 0)
        //{
        //    rewardAmount.text = " ";
        //}
        //else
        //{
        //    rewardAmount.text = kvist.rewardAmount.ToString();
        //}
        //progressText.text = kvist.goal.currentAmount.ToString() + "/" + kvist.goal.requiredAmount.ToString();
        //requiredResourceIMG.sprite = kvist.goal.requiredResourceSprite;


    }

    public void AddQuest(Quest quest, QuestGiver questGiver)
    {
        //player.quests.Add(quest);
        quest.isActive = true;
        quest.questGiver = questGiver;
        quest.Init();
        GameObject panelButton = Instantiate(questButtonPrefab, questPanel.transform.position, Quaternion.identity, questPanel.transform);
        panelButton.GetComponent<QuestButton>().quest = quest;      
        questButtons.Add(panelButton);
    }
    public void RemoveQuest(Quest quest)
    {
        //Spela musikjingle dingle pringles
        musicManager.PlayProgression();

        windowOpen = false;
        questWindow.SetActive(windowOpen);
        quest.isActive = false;
        quest.questGiver.QuestFinished();
        foreach (var button in questButtons)
        {
            if (button.GetComponent<QuestButton>().quest.isActive == false)
            {
                questButtons.Remove(button);
                Destroy(button);
                break;
            }
        }
    }


    void UpdateQuestWindow(Quest quest)
    {
        questTitle.text = quest.title;
        questDescription.text = quest.description;
        rewardImage.sprite = quest.rewardSprite;
        progressText.text = quest.goal.currentAmount.ToString() +  "/" + quest.goal.requiredAmount.ToString();
        requiredResourceIMG.sprite = quest.goal.requiredResourceSprite;
        rewardAmount.text = quest.rewardAmount.ToString();


        //Om bilden för required resource == none, t.ex. interractable uppdrag, så försvinner bilden
        if (quest.goal.requiredResourceSprite == null)
        {
            requiredResourceIMG.gameObject.SetActive(false);
        }
        else
        {
            requiredResourceIMG.gameObject.SetActive(true);
        }
        
        
        //Om man ska få story "reward" så ska det inte synas några rewards
        if (quest.rewardKind == Quest.RewardType.Story) 
        {
            rewardAmount.gameObject.SetActive(false);
            rewardImage.gameObject.SetActive(false);
            justRewardText.gameObject.SetActive(false);

        }
        else
        {
            rewardAmount.gameObject.SetActive(true);
            rewardImage.gameObject.SetActive(true);
            justRewardText.gameObject.SetActive(true);            
        }

    }
}
