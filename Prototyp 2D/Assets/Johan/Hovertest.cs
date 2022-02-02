using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hovertest : MonoBehaviour
{
    public Canvas canvas;
    private bool playerInRange = false;

    public Sprite[] sprites;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            canvas.gameObject.SetActive(false);
            Debug.Log("exit");

        }
    }

    private void OnMouseDown()
    {
        if (playerInRange)
        {
            canvas.gameObject.SetActive(true);
            canvas.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                canvas.transform.position.z);
        }

    }
}
