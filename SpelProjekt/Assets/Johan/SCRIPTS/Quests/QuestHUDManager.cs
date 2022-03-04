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
    public TextMeshProUGUI progressText2;
    public Image requiredResourceIMG2;

    public TextMeshProUGUI justRewardText;
    private Quest currentQuest;
    private MusicManager musicManager;

    [Space]
    public GameObject questButtonPrefab;
    public GameObject questButtonFinished;
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
        rewardAmount.text = quest.rewardAmount.ToString();

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


        //PROGRESS o så

        //Första goalet kommer alltid vara denna
        progressText.text = quest.goals[0].currentAmount.ToString() +  "/" + quest.goals[0].requiredAmount.ToString();
        requiredResourceIMG.sprite = quest.goals[0].requiredResourceSprite;
        switch (quest.goals.Length)
        {

            case 1:
                progressText2.gameObject.SetActive(false);
                requiredResourceIMG2.gameObject.SetActive(false);
                break;

            case 2:
                progressText2.gameObject.SetActive(true);
                requiredResourceIMG2.gameObject.SetActive(true);
                progressText2.text = quest.goals[1].currentAmount.ToString() +  "/" + quest.goals[1].requiredAmount.ToString();
                requiredResourceIMG2.sprite = quest.goals[1].requiredResourceSprite;
                break;
            default:
                break;
        }



        //Borde lösa detta som QuestButton, så det inte är ett bestämt antal goal-texts i windowet. Nåväl
        //För nu kan man ju inta ha mer än 2 goals för det finns bara 2 texter i windowet. Men om man fixar att man kan skrolla så det får plats fler
        //kan man göra som i QúestButton, att det skapas fler => oändliga möjligheter för goals


        //Fungerar ju inte ens, skit

        switch (quest.goals.Length)
        {
            case 1:
                if (quest.goals[0].completed)
                {
                    progressText.color = Color.green;
                }
                else
                {
                    progressText.color = Color.black;
                }
                break;
            case 2:
                if (quest.goals[0].completed)
                {
                    progressText.color = Color.green;
                }
                else
                {
                    progressText.color = Color.black;
                }
                if (quest.goals[1].completed)
                {
                    progressText2.color = Color.green;
                }
                else
                {
                    progressText2.color = Color.black;
                }

                break;
            default:
                break;
        }


        //if (quest.completed)
        //{
        //    //Questwindowetbilden, gör den grön typ eller något
        //    questWindow.GetComponent<Image>().color = new Color(.75f, .95f, .4f);
        //}


        //Om bilden för required resource == none, t.ex. interractable uppdrag, så försvinner bilden
        for (int i = 0; i < quest.goals.Length; i++)
        {
            if (quest.goals[i].requiredResourceSprite == null)
            {
                requiredResourceIMG.gameObject.SetActive(false);
            }
            else
            {
                requiredResourceIMG.gameObject.SetActive(true);
            }
        }

        
        


    }
}
