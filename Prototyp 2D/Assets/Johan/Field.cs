using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private int farmState; //0 = ej plogad, 1 = plogad, 2 = sådd, 3 = grown
    public Canvas canvas;

    private SpriteRenderer spriteRenderer;
    
    public Sprite[] sprites;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
            canvas.GetComponent<CanvasButtons>().UpdateButtons(farmState, this);
            
            canvas.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                canvas.transform.position.z); //kamera grejen blev lustig
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);

        }
    }

    public void ActionButtonPressed(int buttonIndex)
    {

        farmState++;
        if (farmState > 3)
        {
            farmState = 0;
        }
        ChangeImage(buttonIndex);
        canvas.GetComponent<CanvasButtons>().UpdateButtons(farmState, this);
    }

    private void ChangeImage(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }
}
