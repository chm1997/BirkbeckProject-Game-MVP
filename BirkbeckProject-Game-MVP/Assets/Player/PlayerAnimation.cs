using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /// <summary>
    /// This class controls the animations of the player object in response to inputs handled by the input system
    /// </summary>

    public bool isGrounded;
    public bool isWalking;
    public bool speedWalking;
    public bool isAttacking;
    public Vector2 moveInput;
    public PlayerInputs playerInputs;
    public PlayerMovement playerMovement;
    public int currentEnergy;

    public PlayerEnergy playerEnergy;

    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerInputs = GetComponent<PlayerMovement>().playerInputs;
        playerMovement = GetComponent<PlayerMovement>();
        isGrounded = false;
        isWalking = false;
        speedWalking = false;
        isAttacking = false;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentEnergy = playerEnergy.GetPlayerEnergy();
        SidewaysAnimation();
        JumpAnimation();
        AttackAnimation();
        FlipSprite();
    }

    private void FlipSprite()
    {
        // This method flips the sprit in the direction of travel
        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void SidewaysAnimation()
    {
        // This method manages which ground level animation is running based on the player movement variables
        moveInput = playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();

        if (playerInputs.PlayerInputMap.LeftShift.IsPressed()) speedWalking = true;
        else speedWalking = false;

        if (moveInput.x == 0) isWalking = false;
        else isWalking = true;

        isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("penguin_attack");

        if (isGrounded & !isAttacking)
        {
            if (isWalking)
            {
                animator.Play("penguin_walk");
                if (speedWalking & currentEnergy > 0) animator.speed = 2;
                else animator.speed = 1;
            }
            else animator.Play("penguin_idle");
        }


    }
    private void JumpAnimation()
    {
        // This method activates the jump animation when conditions are correct
        if (playerInputs.PlayerInputMap.Jump.triggered & isGrounded)
        {
            isGrounded = false;
            animator.Play("penguin_jump");
            animator.speed = 1;
        }
    }

    private void AttackAnimation()
    {
        // This method activates the attack animation when conditions are correct
        if (playerInputs.PlayerInputMap.MouseButtonLeft.triggered & isGrounded & !isWalking & currentEnergy >= 20) {
            animator.Play("penguin_attack");
            Debug.Log("attack triggered");
            playerEnergy.UpdatePlayerEnergy(-20);
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
        animator.Play("penguin_idle");
    }
}
