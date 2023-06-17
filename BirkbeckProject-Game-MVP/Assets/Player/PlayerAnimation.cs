using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /// <summary>
    /// This class controls the animations of the player object in response to inputs handled by the input system
    /// Required Fields:
    /// </summary>

    public bool isGrounded;
    public bool isWalking;
    public bool isAttacking;
    public Vector2 moveInput;
    public PlayerInputs playerInputs;

    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerInputs = GetComponent<PlayerMovement>().playerInputs;
        isGrounded = false;
        isWalking = false;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        AttackAnimation();
        JumpAnimation();
        SidewaysAnimation();
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

        if (moveInput.x == 0) isWalking = false;
        else isWalking = true;

        if (isGrounded == true & isWalking == true)
        {
            animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_walk_01");
        }
        if (isGrounded == true & isWalking == false)
        {
            animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_idle_01");
        }
    }
    private void JumpAnimation()
    {
        // This method activates the jump animation when conditions are correct
        if (playerInputs.PlayerInputMap.Jump.triggered & isGrounded)
        {
            isGrounded = false;
            animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_jump_01");
        }
    }

    private void AttackAnimation()
    {
        if (playerInputs.PlayerInputMap.MouseButtonLeft.triggered & isGrounded)
        {
            animator.Play("penguin_attack", 0);
            Debug.Log("attacked");
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
        animator.runtimeAnimatorController = Resources.Load<UnityEditor.Animations.AnimatorController>("penguin_idle_01");
    }
}
