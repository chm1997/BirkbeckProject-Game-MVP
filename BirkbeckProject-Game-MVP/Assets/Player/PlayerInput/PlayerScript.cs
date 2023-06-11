using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed; //Recommended: 10
    [SerializeField]
    private float _jumpForce; //Recommended: 750
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private PlayerAmmo playerAmmo;

    private PlayerInputs playerInputs;
    private Rigidbody2D rb2D;
    private Vector2 moveInput;
    private Vector2 jumpInput;
    private bool isGrounded;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        rb2D = GetComponent<Rigidbody2D>();
        isGrounded = false;
        playerHealth.SetPlayerHealth(5);
        playerAmmo.SetPlayerAmmo(3);
    }

    private void Update()
    {
        if (playerInputs.PlayerInputMap.Jump.triggered & playerAmmo.GetPlayerAmmo() > 0 & isGrounded)
        {
            playerAmmo.UpdatePlayerAmmo(-1);
            Jump();
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        moveInput = playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        float verticalMomentum = rb2D.velocity.y;
        rb2D.velocity = new Vector2(moveInput.x * _speed, verticalMomentum);
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void Jump()
    {
        rb2D.AddForce(transform.up * _jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        playerHealth.UpdatePlayerHealth(-1);
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
}