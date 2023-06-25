using UnityEngine;

public class TrainMovementScript : MonoBehaviour
{
    public TrainDataScriptableObject trainData;
    private Rigidbody2D rb2D;
    public float trainSpeed;
    public Vector2 targetVelocity;
    public Vector2 acceleration;
    public Vector2 trainSpeedActual;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        trainSpeed = trainData.GetTrainSpeed();
        HandleTrainMovement();
    }

    private void HandleTrainMovement()
    {
        targetVelocity = transform.right * trainSpeed;
        acceleration = (targetVelocity - rb2D.velocity) / Time.fixedDeltaTime;
        acceleration = Vector2.ClampMagnitude(acceleration, 30);
        rb2D.AddForce(acceleration, ForceMode2D.Impulse);
        trainSpeedActual = rb2D.velocity;
    }
}
