using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private float horizontal;
    private float vertical;

    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private FloatingJoystick joystick;
    private CharacterController characterController;
    private Animator playerAnimator;
    private GameManager gameManager;
    
    private void Start()
    {
        joystick.GetComponent<FloatingJoystick>();
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {

        if (!Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer))
        {
            characterController.Move(Vector3.down * Time.deltaTime * 5f);
        }
        
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        if (horizontal == 0)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        
        if (vertical == 0)
        {
            vertical = Input.GetAxisRaw("Vertical");
        }

        Vector3 motion = horizontal * Vector3.right + vertical * Vector3.forward;
        motion.Normalize();
        characterController.Move(motion * (gameManager.runSpeed * Time.deltaTime));

        Vector3 lookPos = new Vector3(transform.position.x + horizontal, transform.position.y,
            transform.position.z + vertical);

        transform.LookAt(lookPos);

        if (horizontal != 0 || vertical != 0) playerAnimator.SetBool("isRunning", true);
        else playerAnimator.SetBool("isRunning", false);

    }
    
    
    
}
