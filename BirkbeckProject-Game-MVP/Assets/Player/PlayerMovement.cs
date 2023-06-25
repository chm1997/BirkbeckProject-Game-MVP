using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This class controls the movement of the player object in response to inputs handled by the input system
    /// Required Fields:
    /// PlayerHealth playerHealth: a Scriptable Object containing an int variable representing player health
    /// PlayerEnergy playerEnergy: a Scriptable Object containing an int variable representing player energy
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train fuel
    /// float _speed: a variavle representing the speed of horizontal movement
    /// float _jumpForce: a variable representing the height of jumps
    /// </summary>

    [SerializeField]
    internal PlayerHealth playerHealth;
    [SerializeField]
    internal PlayerEnergy playerEnergy;
    [SerializeField]
    internal TrainDataScriptableObject trainData;

    [SerializeField]
    internal float _speed; //Recommended: 10
    [SerializeField]
    internal float _jumpForce; //Recommended: 750

    private GameObject train;

    private Rigidbody2D trainRB2D;
    private Rigidbody2D rb2D;

    internal PlayerInputs playerInputs;

    internal PolygonCollider2D jumpCollider;
    internal PolygonCollider2D groundCollider;

    private Vector2 moveInput;

    internal bool isGrounded;
    private bool shortGroundHop;


    private void Awake()
    {
        // Set up variables required for class functionality
        playerInputs = new PlayerInputs();
        rb2D = GetComponent<Rigidbody2D>();
        isGrounded = false;

        groundCollider = GetComponent<PolygonCollider2D>();

        foreach (PolygonCollider2D pc2d in GetComponentsInChildren<PolygonCollider2D>())
        {
            if (pc2d.transform.parent != this.transform) continue;
            jumpCollider = pc2d;
        }

        jumpCollider.enabled = false;
        groundCollider.enabled = true;
        shortGroundHop = false;
    }

    private void Start()
    {
        // Set up variables required for class functionality
        train = GameObject.FindWithTag("Train");
        if (train != null) trainRB2D = train.GetComponent<Rigidbody2D>();
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
            HandleCollidersOnJump();
        }
    }

    private void SidewaysMovement()
    {
        // This method calculates whether sideways movement is being input and moves the player object in response to it
        moveInput = playerInputs.PlayerInputMap.Movement.ReadValue<Vector2>();
        float verticalMomentum = rb2D.velocity.y;
        Vector2 inputVelocity = new Vector2(moveInput.x * _speed, verticalMomentum);
        Vector2 trainVelocity = TrackTrainMovement();
        rb2D.velocity = inputVelocity + trainVelocity;
    }

    private void ModifySpeed()
    {
        // This method increases the speed of sideways movement when triggered by player input
        if (playerInputs.PlayerInputMap.LeftShift.IsPressed() & isGrounded & playerEnergy.GetPlayerEnergy() > 0 & moveInput != new Vector2(0, 0))
        {
            _speed = 20;
            playerEnergy.UpdatePlayerEnergy(-20 * Time.deltaTime);
        }
        else _speed = 10;
    }

    private Vector2 TrackTrainMovement()
    {
        // This method returns a vector of the movement of the train if the player is in or above the train
        Vector2 returnVector;
        if (trainRB2D != null & trainData.GetPlayerAboveTrain())
        {
            returnVector = trainRB2D.velocity;
        }
        else returnVector = Vector2.zero;
        return returnVector;
    }

    private void HandleCollidersOnJump()
    {
        // This method switches colliders to one more closely matching the midair sprite
        jumpCollider.enabled = true;
        groundCollider.enabled = false;
        shortGroundHop = false;
        StartCoroutine(BringBackSpriteClassic());
    }

    private void HandleCollidersOnLand(Collision2D other)
    {
        // This method switches colliders back to ground on a surprise land (includes handling the state transition)
        if (!shortGroundHop)
        {
            groundCollider.enabled = true;
            jumpCollider.enabled = false;
            shortGroundHop = true;
            transform.position = new Vector2(transform.position.x, other.collider.bounds.max.y + 3);
        }
    }

    private IEnumerator BringBackSpriteClassic()
    {
        // This method waits approximately 2/3rds the length of a jump before switching back colliders
        yield return new WaitForSeconds(1.25f);
        groundCollider.enabled = true;
        jumpCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
        HandleCollidersOnLand(other);
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
