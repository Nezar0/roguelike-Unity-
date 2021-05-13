using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    private float _health;

    private void Start()
    {
        health = (int)(health * GameController.Diffculty()); ;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
