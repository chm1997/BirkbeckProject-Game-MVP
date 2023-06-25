using UnityEngine;

public class TrainAnimationScript : MonoBehaviour
{
    /// <summary>
    /// This class handles updates and changes to animations for the train object
    /// Required fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train fuel
    /// </summary>

    [SerializeField]
    internal TrainDataScriptableObject trainData;

    private SpriteRenderer trainFrontSpriteRenderer;
    
    private void Start()
    {
        // Set up variables required for class functionality
        trainFrontSpriteRenderer = this.gameObject.transform.Find("TrainFrontSprite").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        UpdateTrainFrontSpriteDependingOnPlayerLocation();
    }

    private void UpdateTrainFrontSpriteDependingOnPlayerLocation()
    {
        // This method disables the front sprite of the train object if the player is standing in its area
        trainFrontSpriteRenderer.enabled = !trainData.GetPlayerInTrain();
    }
}
