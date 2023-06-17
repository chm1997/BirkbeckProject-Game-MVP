using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This class controls the movement of the player object in response to inputs handled by the input system
    /// Required Fields:
    /// float _speed: a variavle representing the speed of horizontal movement
    /// float _jumpForce: a variable representing the height of jumps
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// PlayerEnergy playerEnergy: a Scriptable Object containing an int variable representing player energy
    /// </summary>

    public float _speed; //Recommended: 10
    [SerializeField]
    private float _jumpForce; //Recommended: 750
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private PlayerEnergy playerEnergy;

    public bool isGrounded;
    public Vector2 moveInput;
    private Rigidbody2D rb2D;
    public PlayerInputs playerInputs;

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
        ModifySpeed();
        SidewaysMovement();
    }

    private void Jump()
    {
        // This method calculates whether a jump has been triggered and if the player character should be able to jump in this sitation. It applies this force if these are true
        if (playerInputs.PlayerInputMap.Jump.triggered & isGrounded)
        {
            rb2D.AddForce(transform.up * _jumpForce);
            isGrounded = false;
        }
    }

    private void SidewaysMovement()
    {
        // This method calculates whether sideways movement is being input and moves the player object in response to it
        moveInput = playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        float verticalMomentum = rb2D.velocity.y;
        rb2D.velocity = new Vector2(moveInput.x * _speed, verticalMomentum);
    }

    private void ModifySpeed()
    {
        if (playerInputs.PlayerInputMap.LeftShift.IsPressed()) _speed = 20;
        else _speed = 10;
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
