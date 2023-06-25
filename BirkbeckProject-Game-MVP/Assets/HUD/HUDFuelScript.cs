using UnityEngine;
using TMPro;
public class HUDFuelScript : MonoBehaviour
{
    /// <summary>
    /// This class displays a text based on a variable representing a health ScriptableObject
    /// Required fields:
    /// TrainDataScriptableObject trainData: a Scriptable Object containing an float variable representing train fuel
    /// TMP_Text textObject: A text object used to display words on screen
    /// </summary>

    public TrainDataScriptableObject trainData;
    public TMP_Text textObject;
    private string textString;
    public float currentFuel;

    private void Update()
    {
        currentFuel = trainData.GetTrainFuel();
        textString = "Fuel: " + currentFuel.ToString();
        textObject.text = textString;
    }
}
