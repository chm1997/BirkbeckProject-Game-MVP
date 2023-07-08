using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.IO;
using System;
using System.Threading;

public class TestPlayerActionsAndInteractions : InputTestFixture
{
    Vector3 tempPosition;
    bool tempBool;
    LogType tempLogType;

    [UnityTest]
    public IEnumerator TestPlayerActionsAndInteractions_Main()
    {
        // Set up required assets
        DateTime rightNow = DateTime.Now;
        Keyboard keyboard = InputSystem.AddDevice<Keyboard>();
        Mouse mouse = InputSystem.AddDevice<Mouse>();

        string filepath = Application.persistentDataPath + "/Logs/PlayerActionsAndInteractionsLog_" + rightNow.ToString("yyyymddhh") + ".txt";
        Logger logger = new Logger(new TestLogHandler(filepath));

        SceneManager.LoadScene("Assets/Scenes/DesertScene.unity");

        yield return null;
        GameObject player = GameObject.Find("Player");
        GameObject healthPack = GameObject.Find("HealthPack");
        yield return new WaitForSeconds(1f);


        // Test basic movement
        tempPosition = player.transform.position;
        Press(keyboard.rightArrowKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.rightArrowKey);

        tempBool = (player.transform.position.x > tempPosition.x) & (player.transform.position.y == tempPosition.y);
        tempLogType = helperLogMethod(tempBool);
        logger.LogFormat(tempLogType, "Right Movement working: {0}", tempBool);

        yield return null;

        tempPosition = player.transform.position;
        Press(keyboard.leftArrowKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.leftArrowKey);

        tempBool = (player.transform.position.x < tempPosition.x) & (player.transform.position.y == tempPosition.y);
        tempLogType = helperLogMethod(tempBool);
        logger.LogFormat(LogType.Log, "Left Movement working: {0}", tempBool);

        yield return null;

        tempPosition = player.transform.position;
        Press(keyboard.spaceKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.spaceKey);

        tempBool = (player.transform.position.x == tempPosition.x) & (player.transform.position.y > tempPosition.y);
        tempLogType = helperLogMethod(tempBool);
        logger.LogFormat(LogType.Log, "Jump working: {0}", tempBool);

        yield return new WaitForSeconds(1f);

        PlayerDataScriptableObject playerData = player.GetComponent<PlayerScript>().playerData;



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

    private LogType helperLogMethod(bool isWorkingBool)
    {
        LogType returnLogType;
        if (!isWorkingBool) returnLogType = LogType.Error;
        else returnLogType = LogType.Log;
        return returnLogType;
    }
}
