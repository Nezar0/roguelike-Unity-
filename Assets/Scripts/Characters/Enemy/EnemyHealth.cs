using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    private void Start()
    {
        maxHealth = health;
        health = (int)(health * GameController.Diffculty());
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
