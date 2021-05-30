using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;

    public Text healthText;
    public int maxHealth = 20;
    public int currentHealth;

    public GameObject shield;
    public Shield shieldTimer;

    [SerializeField]
    private GameObject PanelGameOver;
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
                if (currentHealth > maxHealth)
                    currentHealth = maxHealth;
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
            currentHealth -= (int)(damage * GameController.Diffculty());
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
    void Die()
    {
        PanelGameOver.SetActive(true);
        if (ES3.FileExists())
        {
            DungeonsComplited.Count = ES3.Load("DungeonsComplited.Count", DungeonsComplited.Count);
        }
        PanelGameOver.GetComponent<GameOver>().textDungeonsCount.text += DungeonsComplited.Count.ToString();
        var es3File = new ES3File("bestResult.es3");
        if (!ES3.FileExists("bestResult.es3"))
        {
            es3File.Save("DungeonsComplited.Count", DungeonsComplited.Count);
            es3File.Sync();
        }
        if (es3File.Load("DungeonsComplited.Count", DungeonsComplited.Count) < DungeonsComplited.Count)
        {
            PanelGameOver.GetComponent<GameOver>().textBestResult.text += DungeonsComplited.Count.ToString();
            es3File.Save("DungeonsComplited.Count", DungeonsComplited.Count);
            es3File.Sync();
        }
        else
        {
            PanelGameOver.GetComponent<GameOver>().textBestResult.text += es3File.Load("DungeonsComplited.Count", DungeonsComplited.Count);
        }
        //}
        ES3.DeleteFile();
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
