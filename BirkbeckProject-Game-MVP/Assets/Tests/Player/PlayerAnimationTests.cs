using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerAnimationTests : InputTestFixture
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    GameObject player;
    PlayerAnimation playerAnimation;
    SpriteRenderer playerSprite;
    Animator playerAnimator;

    Keyboard keyboard;
    Mouse mouse;

    public override void Setup()
    {
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();
        mouse = InputSystem.AddDevice<Mouse>();
    }

    [SetUp]
    public void PlayerAnimationTest_Setup()
    {
        player = GameObject.Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        playerAnimation = player.GetComponent<PlayerAnimation>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerAnimator = player.GetComponent<Animator>();
    }

    [TearDown]
    public void PlayerAnimationTest_TearDown()
    {
        Object.Destroy(player);
        Object.Destroy(playerAnimation);
        Object.Destroy(playerSprite);
        Object.Destroy(playerAnimator);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_FlipOnLeftKey()
    {
        Press(keyboard.leftArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerSprite.flipX);
        
        Release(keyboard.leftArrowKey, 100);

        yield return new WaitForSeconds(0.2f);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_FlipOnAKey()
    {
        Press(keyboard.aKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerSprite.flipX);

        Release(keyboard.aKey);

        yield return new WaitForSeconds(0.2f);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_FlipBackAndForth()
    {
        Press(keyboard.leftArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerSprite.flipX);

        Release(keyboard.leftArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerSprite.flipX);

        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsFalse(playerSprite.flipX);

        Release(keyboard.leftArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsFalse(playerSprite.flipX);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_IdleOnStart()
    {
        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_idle"));

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_Walk()
    {
        playerAnimation.isGrounded = true;
        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));

        Release(keyboard.rightArrowKey);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_WalkAndStop()
    {
        playerAnimation.isGrounded = true;
        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));


        Release(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_idle"));
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_Jump()
    {
        playerAnimation.isGrounded = true;
        PressAndRelease(keyboard.spaceKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_jump"));
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_JumpAndLand()
    {
        playerAnimation.isGrounded = true;
        PressAndRelease(keyboard.spaceKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_jump"));

        playerAnimation.isGrounded = true;

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_idle"));
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_JumpWhenWalking()
    {
        playerAnimation.isGrounded = true;
        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));

        PressAndRelease(keyboard.spaceKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_jump"));

        Release(keyboard.rightArrowKey);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_WalkAndJumpLeft()
    {
        playerAnimation.isGrounded = true;
        Press(keyboard.leftArrowKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));
        Assert.IsTrue(playerSprite.flipX);

        PressAndRelease(keyboard.spaceKey);

        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_jump"));
        Assert.IsTrue(playerSprite.flipX);

        Release(keyboard.leftArrowKey);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_AttackFromIdle()
    {
        playerAnimation.isGrounded = true;

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_idle"));

        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"));
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_NoAttackWhenWalking()
    {
        playerAnimation.isGrounded = true;
        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.1f);

        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));
        Assert.IsFalse(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"));

        Release(keyboard.rightArrowKey);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_NoAttackWhenJumping()
    {
        playerAnimation.isGrounded = false;
        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);

        Assert.IsFalse(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"));
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_NoAttackWhenNoEnergy()
    {
        playerAnimation.playerEnergy.SetPlayerEnergy(0);
        playerAnimation.isGrounded = true;
        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);
        Assert.IsFalse(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"));
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_AttackUsesEnergy()
    {
        playerAnimation.playerEnergy.SetPlayerEnergy(100);
        playerAnimation.isGrounded = true;
        PressAndRelease(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_attack"));
        Debug.Log(playerAnimation.playerEnergy.GetPlayerEnergy());
        Assert.Less(playerAnimation.playerEnergy.GetPlayerEnergy(), 100);
    }


    [UnityTest]
    public IEnumerator PlayerAnimationTest_SpeedUpWalkOnShiftKey()
    {
        playerAnimation.isGrounded = true;
       
        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.1f);
        Press(keyboard.leftShiftKey);
        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));
        Assert.IsTrue(playerAnimator.speed > 1);

        Release(keyboard.leftShiftKey);
        Release(keyboard.rightArrowKey);
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest_NoSpeedWalkWhenNoEnergy()
    {
        playerAnimation.playerEnergy.SetPlayerEnergy(0);
        playerAnimation.isGrounded = true;

        Press(keyboard.rightArrowKey);

        yield return new WaitForSeconds(0.1f);

        Press(keyboard.leftShiftKey);

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walk"));
        Assert.IsTrue(playerAnimator.speed == 1);

        Release(keyboard.leftShiftKey);
        Release(keyboard.rightArrowKey);
    }
}