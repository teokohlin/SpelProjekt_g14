using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4;
    public Rigidbody2D rb;

    public Canvas hoverCanvas;
    
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetMouseButtonDown(0))
        {
            //hoverCanvas.gameObject.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * (moveSpeed * Time.fixedDeltaTime));
    }
    
    
    
    
}
