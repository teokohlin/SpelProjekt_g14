using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Player player;
    [Space]
    public Quest quest;

    public GameObject questWindow;


    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        
    }

}
