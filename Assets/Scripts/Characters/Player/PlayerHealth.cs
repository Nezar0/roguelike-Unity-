using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;

    public Text healthText;
    public int maxHealth = 20;
    public int currentHealth;

    public GameObject shield;
    public Shield shieldTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("potion_red"))
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += 5;
                healthText.text = "HP: " + currentHealth;
            }
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("potion_green"))
        {
            if (!shield.activeInHierarchy)
            {
                shield.SetActive(true);
                shieldTimer.gameObject.SetActive(true);
                shieldTimer.isCooldown = true;
                Destroy(collision.gameObject);
            }
            else
            {
                shieldTimer.ResetTimer();
                Destroy(collision.gameObject);
            }
        }
    }

    //получение урона 
    public void TakeDamage(int damage)
    {
        if (!shield.activeInHierarchy)
        {
            currentHealth -= damage;
            //healthBar.SetHealth(currentHealth);
            StartCoroutine(DamageAnimation());
            healthText.text = "HP: " + currentHealth;
            if (currentHealth <= 0)
            {
                healthText.text = "HP: 0";
                Die();
                Time.timeScale = 0;
            }
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
