using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    Vector3 movement;

    [SerializeField] float forwardSpeed = 100;
    [SerializeField] float backwardSpeed = 50;
    [SerializeField] float turnSpeed= 1.5f;



    private float timer;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);

        if (animator.GetBool("Hitted") == true)
        {
            timer += Time.deltaTime;

            if (timer >= 0.5f)
            {
                animator.SetBool("Hitted", false);
                timer = 0;
            }

        }




        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (vertical != 0)
        {
            float moveSpeedToUSe = (vertical > 0) ? forwardSpeed : backwardSpeed;

            characterController.SimpleMove(transform.forward * moveSpeedToUSe * vertical);
        }
    }
}
