using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed; //Recommended: 10
    [SerializeField]
    private float _jumpForce; //Recommended: 750
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private PlayerAmmo playerAmmo;

    private bool isGrounded;
    private Vector2 moveInput;
    private Vector2 jumpInput;
    private Rigidbody2D rb2D;
    private PlayerInputs playerInputs;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        rb2D = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        SidewaysMovement();
    }

    private void Jump()
    {
        if (playerInputs.PlayerInputMap.Jump.triggered & playerAmmo.GetPlayerAmmo() > 0 & isGrounded)
        {
            playerAmmo.UpdatePlayerAmmo(-1);
            rb2D.AddForce(transform.up * _jumpForce);
            isGrounded = false;
        }
    }

    private void SidewaysMovement()
    {
        moveInput = playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        float verticalMomentum = rb2D.velocity.y;
        rb2D.velocity = new Vector2(moveInput.x * _speed, verticalMomentum);
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
