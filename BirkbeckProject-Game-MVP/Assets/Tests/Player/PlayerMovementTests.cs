using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerMovementTests : InputTestFixture
{
    
    GameObject playerPrefab = Resources.Load<GameObject>("Player");
    GameObject player;
    PlayerMovement playerMovement;
    Rigidbody2D playerRB2D;

    Keyboard keyboard;

    public override void Setup()
    {
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    [SetUp]
    public void PlayerMovementTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        playerRB2D = player.GetComponent<Rigidbody2D>();
        playerRB2D.gravityScale = 0;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    [TearDown]
    public void PlayerMovementTest_TearDown()
    {
        Object.Destroy(player);
        Object.Destroy(playerRB2D);
        Object.Destroy(playerMovement);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_HorizontalLeftArrow()
    {
        Press(keyboard.leftArrowKey);
        yield return new WaitForSeconds(0.2f);
        Release(keyboard.leftArrowKey);

        Assert.LessOrEqual(player.transform.position.x, -1);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_HorizontalRightArrow()
    {
        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.rightArrowKey);

        Assert.GreaterOrEqual(player.transform.position.x, 1);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_HorizontalAKey()
    {

        Press(keyboard.aKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.aKey);

        Assert.LessOrEqual(player.transform.position.x, -1);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_HorizontalDKey()
    {
        Press(keyboard.dKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.dKey);

        Assert.GreaterOrEqual(player.transform.position.x, 1);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_VerticalMoveUpFixed()
    {

        Press(keyboard.upArrowKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.upArrowKey);

        Assert.AreEqual(0, player.transform.position.x);
        Assert.AreEqual(0, player.transform.position.y);

        Press(keyboard.wKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.wKey);

        Assert.AreEqual(0, player.transform.position.x);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_VerticalMoveDownFixed()
    {
        Press(keyboard.downArrowKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.downArrowKey);

        Assert.AreEqual(0, player.transform.position.x);
        Assert.AreEqual(0, player.transform.position.y);

        Press(keyboard.sKey);

        yield return new WaitForSeconds(0.2f);

        Release(keyboard.sKey);

        Assert.AreEqual(0, player.transform.position.x);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_JumpMoveUp()
    {
        playerMovement.isGrounded = true;
        PressAndRelease(keyboard.spaceKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsFalse(playerMovement.isGrounded);
        Assert.AreEqual(0, player.transform.position.x);
        Assert.GreaterOrEqual(player.transform.position.y, 1);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_JumpDoesntTriggerWhenNotGrounded()
    {
        playerMovement.isGrounded = false;
        PressAndRelease(keyboard.spaceKey);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(0, player.transform.position.x);
        Assert.AreEqual(0, player.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_WalkSpedUp()
    {
        playerMovement.isGrounded = true;

        Press(keyboard.rightArrowKey);
        Press(keyboard.leftShiftKey);

        yield return new WaitForSeconds(0.2f);

        Assert.GreaterOrEqual(player.transform.position.x, 1);
        Assert.AreEqual(0, player.transform.position.y);
        Assert.Greater(playerMovement._speed, 10);

        Release(keyboard.rightArrowKey);
        Release(keyboard.leftShiftKey);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_SlowDownOnShiftRelease()
    {
        playerMovement.isGrounded = true;

        Press(keyboard.rightArrowKey);
        Press(keyboard.leftShiftKey);

        yield return new WaitForSeconds(0.2f);

        Assert.GreaterOrEqual(player.transform.position.x, 1);
        Assert.AreEqual(0, player.transform.position.y);
        Assert.Greater(playerMovement._speed, 10);

        Release(keyboard.rightArrowKey);
        Release(keyboard.leftShiftKey);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(playerMovement._speed, 10);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_SpeedWalkUsesEnergy()
    {
        playerMovement.isGrounded = true;

        playerMovement.playerData.SetPlayerEnergy(100);
        Press(keyboard.rightArrowKey);
        Press(keyboard.leftShiftKey);

        yield return new WaitForSeconds(0.2f);

        Assert.GreaterOrEqual(player.transform.position.x, 1);
        Assert.AreEqual(0, player.transform.position.y);
        Assert.Greater(playerMovement._speed, 10);
        Assert.Less(playerMovement.playerData.GetPlayerEnergy(), 100);

        Release(keyboard.rightArrowKey);
        Release(keyboard.leftShiftKey);
    }

    [UnityTest]
    public IEnumerator PlayerMovementTest_NoSpeedWalkWhenNoEnergy()
    {
        playerMovement.isGrounded = true;
        playerMovement.playerData.SetMaxEnergy(0);
        playerMovement.playerData.SetPlayerEnergy(0);
        Press(keyboard.rightArrowKey);
        Press(keyboard.leftShiftKey);

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(playerMovement._speed, 10);

        Release(keyboard.rightArrowKey);
        Release(keyboard.leftShiftKey);
    }
}