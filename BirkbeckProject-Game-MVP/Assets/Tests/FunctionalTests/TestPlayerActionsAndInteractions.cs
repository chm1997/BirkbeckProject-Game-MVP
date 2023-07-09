using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.IO;
using System;
using TMPro;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class TestPlayerActionsAndInteractions : InputTestFixture
{
    Vector3 tempPosition;
    float tempNum;
    string tempString;
    Logger logger;

    [UnityTest]
    public IEnumerator TestPlayerActionsAndInteractions_Main()
    {
        // Set up required assets
        DateTime rightNow = DateTime.Now;
        Keyboard keyboard = InputSystem.AddDevice<Keyboard>();
        Mouse mouse = InputSystem.AddDevice<Mouse>();

        string filepath = Application.persistentDataPath + "/Logs/PlayerActionsAndInteractionsLog_" + rightNow.ToString("yyyy-MM-dd-hh-mm") + ".txt";
        logger = new Logger(new TestLogHandler(filepath));

        SceneManager.LoadScene("Assets/Scenes/TestScene.unity");

        yield return null;

        GameObject player = GameObject.Find("Player");
        GameObject train = GameObject.Find("TrainMainObject");
        GameObject crosshair = GameObject.Find("Crosshair");
        GameObject healthPack = GameObject.Find("HealthPack");
        GameObject fuelPack = GameObject.Find("FuelPack");
        GameObject healthText = GameObject.Find("Health Text");
        GameObject fuelText = GameObject.Find("Fuel Text");
        GameObject energyText = GameObject.Find("Energy Text");

        PlayerDataScriptableObject playerData = player.GetComponent<PlayerScript>().playerData;
        TrainDataScriptableObject trainData = train.GetComponent<TrainScript>().trainData;

        

        yield return new WaitForSeconds(1f);

        // Test Player Movement and Animations

        tempPosition = player.transform.position;
        HelperCheckMethod(
            player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_idle"),
            "Idle animation working: {0}"
        );

        tempPosition = player.transform.position;
        Press(keyboard.rightArrowKey);
        yield return new WaitForSeconds(1f);

        HelperCheckMethod(
            player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"),
            "Right movement animation working: {0}"
        );

        Release(keyboard.rightArrowKey);

        HelperCheckMethod(
            (player.transform.position.x > tempPosition.x) & (player.transform.position.y == tempPosition.y),
            "Right Movement working: {0}"
        );

        tempNum = Mathf.Abs(player.transform.position.x - tempPosition.x);

        yield return null;

        tempPosition = player.transform.position;
        Press(keyboard.leftArrowKey);
        yield return new WaitForSeconds(1f);

        HelperCheckMethod(
            player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"),
            "Left movement animation working: {0}"
        );

        Release(keyboard.leftArrowKey);

        HelperCheckMethod(
            (player.transform.position.x < tempPosition.x) & (player.transform.position.y == tempPosition.y),
            "Left movement working: {0}"
        );

        yield return null;

        playerData.SetPlayerEnergy(100);

        tempPosition = player.transform.position;
        Press(keyboard.rightArrowKey);
        Press(keyboard.leftShiftKey);
        yield return new WaitForSeconds(0.5f);

        Release(keyboard.rightArrowKey);
        Release(keyboard.leftShiftKey);

        HelperCheckMethod(
            (Mathf.Abs(Mathf.Abs(player.transform.position.x - tempPosition.x) - tempNum) < 0.5f),
            "Double speed movement working: {0}"
        );

        HelperCheckMethod(
            (playerData.GetPlayerEnergy() < 100),
            "Energy reduction on run working: {0}"
        );

        yield return null;

        tempPosition = player.transform.position;
        PressAndRelease(keyboard.spaceKey);
        yield return new WaitForSeconds(1f);

        HelperCheckMethod(
            player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_jump"),
            "Jump animation working: {0}"
        );

        HelperCheckMethod(
            (player.transform.position.x == tempPosition.x) & (player.transform.position.y > tempPosition.y),
            "Jump working: {0}"
        );

        yield return new WaitForSeconds(2f);

        playerData.SetPlayerEnergy(100);
        Press(keyboard.eKey);

        yield return null;
        yield return null;

        HelperCheckMethod(
            player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"),
            "Attack animation working: {0}"
        );

        HelperCheckMethod(
            (playerData.GetPlayerEnergy() < 100),
            "Energy reduction on run working: {0}"
        );

        // Test Mouse movement and object interaction

        tempPosition = crosshair.transform.position;
        tempNum = playerData.GetPlayerHealth();
        tempString = healthText.GetComponent<TextMeshProUGUI>().text;
        Move(mouse.position, (Camera.main.WorldToScreenPoint(healthPack.transform.position)));

        yield return new WaitForSeconds(0.1f);

        HelperCheckMethod(
            (crosshair.transform.position != tempPosition),
            "Mouse move working: {0}"
        );

        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);

        HelperCheckMethod(
            (playerData.GetPlayerHealth() > tempNum),
            "Mouse click object interaction working: {0}"
        );

        HelperCheckMethod(
            (healthPack == null),
            "Health Pack object behaviour working: {0}"
        );

        HelperCheckMethod(
            (healthText.GetComponent<TextMeshProUGUI>().text != tempString),
            "Health HUD Text behaviour working: {0}"
        );

        yield return null;

        tempNum = trainData.GetTrainFuel();
        tempString = fuelText.GetComponent<TextMeshProUGUI>().text;
        Move(mouse.position, (Camera.main.WorldToScreenPoint(fuelPack.transform.position)));

        yield return new WaitForSeconds(0.1f);

        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);

        HelperCheckMethod(
            ((trainData.GetTrainFuel() > tempNum) & (fuelPack == null)),
            "Fuel Pack object behaviour working: {0}"
        );

        HelperCheckMethod(
            (fuelText.GetComponent<TextMeshProUGUI>().text != tempString),
            "Fuel HUD Text behaviour working: {0}"
        );

        yield return new WaitForSeconds(0.1f);
        
        tempString = energyText.GetComponent<TextMeshProUGUI>().text;
        Press(keyboard.eKey);

        yield return new WaitForSeconds(0.1f);

        HelperCheckMethod(
            (energyText.GetComponent<TextMeshProUGUI>().text != tempString),
            "Energy HUD Text behaviour working: {0}"
        );

        // Test Enemy interactions, death, and game over screen

        GameObject enemySpawner = GameObject.Instantiate(Resources.Load<GameObject>("EnemySpawner"), new Vector3(0, 0, 0), Quaternion.identity);
        EnemyDataScriptableObject enemyData = enemySpawner.GetComponent<EnemySpawnerScript>().enemyData;
        enemyData.SetEnemyCountMax(1);

        tempNum = playerData.GetPlayerHealth();
        yield return new WaitForSeconds(2f);

        HelperCheckMethod(
            (playerData.GetPlayerHealth() < tempNum),
            "Energy HUD Text behaviour working: {0}"
        );

        playerData.SetPlayerHealth(1);
        yield return new WaitForSeconds(2f);

        HelperCheckMethod(
            (SceneManager.GetActiveScene().name == "Game Over Scene"),
            "Game over screen working: {0}"
        );

        HelperCheckMethod(
            (player == null),
            "Player death working: {0}"
        );

        GameObject restartButton = GameObject.Find("RestartScriptObject");
        Move(mouse.position, (restartButton.transform.position));
        yield return new WaitForSeconds(0.1f);

        Press(mouse.leftButton);
        restartButton.SendMessage("OnPressed");

        yield return new WaitForSeconds(0.1f);

        HelperCheckMethod(
            (SceneManager.GetActiveScene().name == "DesertScene"),
            "Restart button working: {0}"
        );

        // Test Train interactions

        // Read log file and check for failures
        logger.LogFormat(LogType.Log, "Close");
        ReadLogs(filepath);
    }

    private void ReadLogs(string filepath)
    {
        StreamReader streamReader = new StreamReader(filepath);
        List<string> failures = new List<string>();
        string line = streamReader.ReadLine();

        while (line != null)
        {
            if (line.EndsWith("False")) failures.Add(line);
            line = streamReader.ReadLine();
        }
        Assert.AreEqual(failures.Count, 0, failures.ToString());
    }

    private void HelperCheckMethod(bool isWorkingBool, string formatString)
    {
        logger.LogFormat(HelperLogMethod(isWorkingBool), formatString, isWorkingBool);
    }

    private LogType HelperLogMethod(bool isWorkingBool)
    {
        LogType returnLogType;
        if (!isWorkingBool) returnLogType = LogType.Error;
        else returnLogType = LogType.Log;
        return returnLogType;
    }
}
