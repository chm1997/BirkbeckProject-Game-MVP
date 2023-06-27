using UnityEngine;

public class TrainMovementScript : MonoBehaviour
{
    /// <summary>
    /// This class controls the movement of the train object based on values in the train data scriptable object
    /// Required fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train fuel
    /// </summary>
    
    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private Rigidbody2D rb2D;

    private Vector2 targetVelocity;
    private Vector2 acceleration;

    private float trainSpeed;

    private void Start()
    {
        // Set up variables required for class functionality
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleTrainMovement();
    }

    private void HandleTrainMovement()
    {
        // This method accelerates the train object up to the speed set by the scriptable object of train data
        trainSpeed = trainData.GetTrainSpeed();
        targetVelocity = transform.right * trainSpeed;
        acceleration = (targetVelocity - rb2D.velocity) / Time.fixedDeltaTime;
        acceleration = Vector2.ClampMagnitude(acceleration, 30);
        rb2D.AddForce(acceleration, ForceMode2D.Impulse);
    }
}
