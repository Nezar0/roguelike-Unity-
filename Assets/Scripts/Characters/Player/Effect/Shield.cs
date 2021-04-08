using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float cooldown;

    public bool isCooldown;

    private Image shieldImg;
    private PlayerHealth player;
    void Start()
    {
        shieldImg = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        isCooldown = true;
    }

    void Update()
    {
        if(isCooldown)
        {
            shieldImg.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(shieldImg.fillAmount <= 0)
            {
                shieldImg.fillAmount = 1;
                isCooldown = false;
                player.shield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    } 
    public void ResetTimer()
    {
        shieldImg.fillAmount = 1;
    }
}
