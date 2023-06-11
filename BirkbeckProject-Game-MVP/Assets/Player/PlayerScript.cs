using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private PlayerAmmo playerAmmo;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerHealth.SetPlayerHealth(5);
        playerAmmo.SetPlayerAmmo(3);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        playerHealth.UpdatePlayerHealth(-1);
    }
}