using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.IO;
using System;

public class TestPlayerActionsAndInteractions : InputTestFixture
{
    Vector3 tempPosition;
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

        SceneManager.LoadScene("Assets/Scenes/DesertScene.unity");

        yield return null;
        GameObject player = GameObject.Find("Player");
        GameObject healthPack = GameObject.Find("HealthPack");
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

        Press(keyboard.eKey);

        yield return null;
        yield return null;

        HelperCheckMethod(
            player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"),
            "Attack animation working: {0}"
        );

        // Test Mouse movement and object interaction

        // Test Train interactions

        // Test Enemy interactions, death, and game over screen

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
