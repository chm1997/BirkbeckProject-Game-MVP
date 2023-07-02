using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /// <summary>
    /// This class controls the animations of the player object in response to inputs handled by the input system
    /// Required Fields:
    /// PlayerDataScriptableObject playerData: a Scriptable Object containing an int variable representing player data
    /// </summary>

    [SerializeField]
    internal PlayerDataScriptableObject playerData;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerInputs playerInputs;

    private Vector2 moveInput;

    private float currentEnergy;

    internal bool isGrounded;
    private bool isWalking;
    private bool speedWalking;
    private bool isAttacking;

    void Start()
    {
        // Set up variables required for class functionality
        playerInputs = GetComponent<PlayerMovement>().playerInputs;
        isGrounded = false;
        isWalking = false;
        speedWalking = false;
        isAttacking = false;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentEnergy = playerData.GetPlayerEnergy();
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
        if (playerInputs.PlayerInputMap.AttackButton.triggered & isGrounded & !isWalking & currentEnergy >= 20) {
            animator.Play("penguin_attack");
            playerData.UpdatePlayerEnergy(-20);
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
        animator.Play("penguin_idle");
    }
}
