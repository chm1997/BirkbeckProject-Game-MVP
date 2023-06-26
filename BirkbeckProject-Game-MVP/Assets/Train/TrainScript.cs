using System.Collections;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    /// <summary>
    /// This class represents the train objects' general states and behaviours
    /// Required fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train fuel
    /// </summary>

    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private Rigidbody2D rb2d;

    private SpriteRenderer trainFrontSpriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private Vector3 playerPosForContains;
    private Vector3 playerPosForAbove;

    private bool freezePositionBool;

    private void Awake()
    {
        TrainDataSetUp();   
    }

    private void Start()
    {
        // Set up variables required for class functionality
        rb2d = GetComponent<Rigidbody2D>();

        trainFrontSpriteRenderer = this.gameObject.transform.Find("TrainMainSpriteObject").transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();

        freezePositionBool = false;
        StartCoroutine(Wait1Second());
    }

    private void Update()
    {
        TrackPlayerPositionInRelationToTrain();
        TrackTrainFuelUsage();
        SetTrainGravity();
    }

    private void TrackPlayerPositionInRelationToTrain()
    {
        // This method calculates whether the player object can be considered inside the bounds of the train or on top of it
        if (playerSpriteRenderer != null & trainFrontSpriteRenderer != null)
        {
            playerPosForContains = new Vector3(playerSpriteRenderer.bounds.center.x, playerSpriteRenderer.bounds.center.y, -2);
            playerPosForAbove = new Vector3(playerSpriteRenderer.bounds.center.x, trainFrontSpriteRenderer.bounds.center.y, -2);

            trainData.SetPlayerInTrain(trainFrontSpriteRenderer.bounds.Contains(playerPosForContains));
            trainData.SetPlayerAboveTrain(trainFrontSpriteRenderer.bounds.Contains(playerPosForAbove));
        }
    }

    private void TrackTrainFuelUsage()
    {
        // This method slowly drains train fuel when train speed isn't zero (effectively, when the train is moving) and prevents movement if train fuel out
        if (trainData.GetTrainSpeed() > 0)
        {
            if (trainData.GetTrainFuel() > 0)
            {
                trainData.UpdateTrainFuel(-1 * Time.deltaTime);
            }
            else trainData.SetTrainSpeed(0);
        }
    }

    private void SetTrainGravity()
    {
        if (freezePositionBool)
        {
            if (!trainData.GetPlayerAboveTrain()) rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            else rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }

    private IEnumerator Wait1Second()
    {
        yield return new WaitForSeconds(1);
        freezePositionBool = true;
    }

    private void TrainDataSetUp()
    {
        // Set up values for the train data object
        trainData.SetMaxTrainFuel(1000);
        trainData.SetTrainFuel(1000);

        trainData.SetMaxTrainHealth(1000);
        trainData.SetTrainHealth(1000);

        trainData.SetMaxTrainSpeed(100);
        trainData.SetTrainSpeed(0);

        trainData.SetPlayerInTrain(false);
        trainData.SetPlayerAboveTrain(false);
    }
}
