using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    //получение урона 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        StartCoroutine(DamageAnimation());
        if (currentHealth <= 0)
        {
            Die();
            Time.timeScale = 0;
        }
    }
    //смерть и загрузка таблицы рекордов
    void Die()
    {
        //anim.SetInteger("anim", 5);
        Destroy(gameObject, 0.8f);
    }
    //анимация получения урона 
    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
