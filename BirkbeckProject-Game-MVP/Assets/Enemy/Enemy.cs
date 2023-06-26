using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagingObject, IEnemy
{
    public bool isDamaging { get; set; }
    public int damageValue { get; set; }

    private void Start()
    {
        isDamaging = true;
        damageValue = 1;
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {

    }
}
