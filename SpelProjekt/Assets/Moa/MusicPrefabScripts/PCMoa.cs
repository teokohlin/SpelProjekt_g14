#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PCMoa : MonoBehaviour
{
    private CharacterController controller;
    public GameObject characterModel;
    public Animator animator;

    [Header("Movement")] public float speed = 12f;
    [Header("Dash")] public float dashLenght = 3;
    public float dashCooldown = 1f;
    private float dashTimer = 5;
    private float gravity = -10;
    private Vector3 gravityFactor = new Vector3();
    Vector3 velocity;

    public bool inAttack;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void FlipInAttack()
    {
        if (inAttack)
            inAttack = false;
        else
            inAttack = true;
    }


    void Update()
    {
        characterModel.transform.localPosition = Vector3.zero;
        float x;
        float z;
        bool dashPressed = false;
        dashTimer += Time.deltaTime;

        if (inAttack)
        {
            animator.SetBool("IsRunning", false);
            return;
        }

#if ENABLE_INPUT_SYSTEM
        var delta = movement.ReadValue<Vector2>();
        x = delta.x;
        z = delta.y;
        dashPressed = Mathf.Approximately(dash.ReadValue<float>(), 1);
#else
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        dashPressed = Input.GetButtonDown("Dash");
#endif

        if (!controller.isGrounded)
        {
            gravityFactor.y = -0.01f;
            gravityFactor.y += gravity * Time.deltaTime;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(gravityFactor + move * speed * Time.deltaTime);

        // When the animator should start running animation
        if (move.magnitude > 0 + 0.4f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (dashPressed && dashTimer >= dashCooldown)
        {
            StartCoroutine(Dash());
        }



        Vector3 lookDirection = new Vector3(x, 0.0f, z);
        characterModel.transform.LookAt(characterModel.transform.position + lookDirection);

        IEnumerator Dash()
        {
            if (move.magnitude > 0)
            {
                velocity = move.normalized * 0.1f * dashLenght;
            }
            else
            {
                velocity = characterModel.transform.forward.normalized * 0.1f * dashLenght;
            }

            Vector3 startPos = transform.position;
            int dashFrames = 0;

            while (dashFrames < 16)
            {
                controller.Move(velocity);
                dashFrames++;
                yield return null;
                dashTimer = 0;
            }

        }
    }



}
