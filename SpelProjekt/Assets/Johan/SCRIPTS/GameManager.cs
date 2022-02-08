using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player = null;

    [Tooltip("Spelare, kamera, gamemanager framf�rallt. Kanske musik")]
    public GameObject[] dontDestroyOnLoadObjects = null;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        
        foreach  (GameObject g in dontDestroyOnLoadObjects)
        {
            DontDestroyOnLoad(g);
        }
    }

    public void ChangeScene(string targetSceneName, Vector3 playerPosition)
    {
        SceneManager.LoadScene(targetSceneName, LoadSceneMode.Single);
        player.transform.position = playerPosition;
    }

}
