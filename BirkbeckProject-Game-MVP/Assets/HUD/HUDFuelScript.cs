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

    [SerializeField]
    internal TrainDataScriptableObject trainData;
    [SerializeField]
    internal TMP_Text textObject;

    private string textString;
    private int currentFuel;

    private void Update()
    {
        UpdateFuelText();
    }

    private void UpdateFuelText()
    {
        // This method updates the text object to match the trainData object
        currentFuel = (int)trainData.GetTrainFuel();
        textString = "Fuel: " + currentFuel.ToString();
        textObject.text = textString;
    }
}
