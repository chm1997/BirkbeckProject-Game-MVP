using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /// <summary>
    /// This class controls the animations of the player object in response to inputs handled by the input system
    /// Required Fields:
    /// PlayerAmmo playerAmmo: a Scriptable Object containing an int variable representing player ammo
    /// </summary>

    public bool isGrounded;
    public bool isWalking;
    public Vector2 moveInput;
    public PlayerInputs playerInputs;
    public PlayerAmmo playerAmmo;

    Animator animator;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        playerInputs = GetComponent<PlayerMovement>().playerInputs;
        isGrounded = false;
        isWalking = false;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        SidewaysAnimation();
        JumpAnimation();
    }

    private void SidewaysAnimation()
    {
        // This method manages which ground level animation is running based on the player movement variables
        moveInput = playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();

        if (moveInput == new Vector2(0, 0)) isWalking = false;
        else isWalking = true;

        if (isGrounded == true & isWalking == true)
        {
            animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_walk_01");
        }
        if (isGrounded == true & isWalking == false)
        {
            animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_idle_01");
        }

        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    private void JumpAnimation()
    {
        // This method activates the jump animation when conditions are correct
        if (playerInputs.PlayerInputMap.Jump.triggered & playerAmmo.GetPlayerAmmo() > 0 & isGrounded)
        {
            isGrounded = false;
            animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_jump_01");
        }
    }
    private void OnCollisionEnter2D()
    {
        isGrounded = true;
        animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_idle_01");
    }
}
