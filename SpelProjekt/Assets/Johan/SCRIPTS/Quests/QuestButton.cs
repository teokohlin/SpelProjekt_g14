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
    public Sprite originalSprite;
    public Sprite completedSprite;

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
        //Quest Title
        titleText.text = quest.title;

        //Every goal
        for (int i = 0; i < progressObjects.Count; i++)
        {
            //Text
            progressObjects[i].GetComponentInChildren<TextMeshProUGUI>().text =
                quest.goals[i].currentAmount.ToString() +  "/" + quest.goals[i].requiredAmount.ToString();

            if (quest.goals[i].completed)
            {
                progressObjects[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
            }
            else
            {
                progressObjects[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }



            //Images
            if (quest.goals[i].requiredResourceSprite == null)
            {
                if (progressObjects[i].GetComponentInChildren<Image>() != null)
                {
                    progressObjects[i].GetComponentInChildren<Image>().gameObject.SetActive(false);
                }


                //if (progressObjects[i].TryGetComponent<Image>(out Image image)) //Behövdes tydligen för det kunde bli error när knappen tas bort mitt i
                //{
                //    image.gameObject.SetActive(false);
                //}
            }
            else
            {
                progressObjects[i].GetComponentInChildren<Image>().gameObject.SetActive(true);
                progressObjects[i].GetComponentInChildren<Image>().sprite =
                quest.goals[i].requiredResourceSprite;
            }

        }

        if (quest.completed)
        {
            //GetComponent<Image>().color = Color.green;
            GetComponent<Image>().sprite = completedSprite;
        }
        else
        {
            GetComponent<Image>().sprite = originalSprite;
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
