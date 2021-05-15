using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public HealthBar healthBar;
    void Start()
    {
        healthBar.SetHealth(GetComponent<EnemyHealth>().health, GetComponent<EnemyHealth>().maxHealth);
    }
    void Update()
    {
        healthBar.SetHealth(GetComponent<EnemyHealth>().health, GetComponent<EnemyHealth>().maxHealth);
        if (GetComponent<EnemyHealth>().health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
