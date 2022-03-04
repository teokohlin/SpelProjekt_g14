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
    //public TextMeshProUGUI progressText;
    //public Image requiredResourceImage;
    public GameObject panelInPanel;
    public GameObject progressPrefab;
    public List<GameObject> progressObjects = new List<GameObject>();

    private void Start()
    {
        questHUD = GetComponentInParent<QuestHUDManager>();
        titleText.text = quest.title;
        for (int i = 0; i < quest.goals.Length; i++)
        {
            //progressObjects[i].GetComponentInChildren<TextMeshProUGUI>()
            GameObject progressObj = Instantiate(progressPrefab, panelInPanel.transform.position, Quaternion.identity, panelInPanel.transform);
            //progressObj.transform.parent = panelInPanel.transform;
            progressObjects.Add(progressObj);
        }
        //progressText.text = quest.goals[0].currentAmount.ToString() +  "/" + quest.goals[0].requiredAmount.ToString();
        //requiredResourceImage.sprite = quest.goals[0].requiredResourceSprite;

    }
    private void Update()
    {
        titleText.text = quest.title;

        for (int i = 0; i < progressObjects.Count; i++)
        {
            progressObjects[i].GetComponentInChildren<TextMeshProUGUI>().text =
                quest.goals[i].currentAmount.ToString() +  "/" + quest.goals[i].requiredAmount.ToString();
            progressObjects[i].GetComponentInChildren<Image>().sprite =
                quest.goals[i].requiredResourceSprite;
            if (quest.goals[i].requiredResourceSprite == null)
            {
                 progressObjects[i].GetComponentInChildren<Image>().gameObject.SetActive(false);
            }
            else
            {
                progressObjects[i].GetComponentInChildren<Image>().gameObject.SetActive(true);
            }

        }


        //progressText.text = quest.goals[0].currentAmount.ToString() +  "/" + quest.goals[0].requiredAmount.ToString();
        //requiredResourceImage.sprite = quest.goals[0].requiredResourceSprite;
        //if (quest.goals[0].requiredResourceSprite == null)
        //{
        //    requiredResourceImage.gameObject.SetActive(false);
        //}
        //else
        //{
        //    requiredResourceImage.gameObject.SetActive(true);
        //}



    }

    public void ButtonPressed()
    {
        questHUD.OpenQuestWindow(quest);
    }

}
