using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSpeed : MonoBehaviour
{
    public float cooldown;

    public bool isCooldown;

    private Image addSpeedImg;
    private PlayerMovement player;
    void Start()
    {
        addSpeedImg = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        isCooldown = true;
    }

    void Update()
    {
        if (isCooldown)
        {
            addSpeedImg.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (addSpeedImg.fillAmount <= 0)
            {
                addSpeedImg.fillAmount = 1;
                isCooldown = false;
                player.currentMoveSpeed = player.maxMoveSpeed;
                gameObject.SetActive(false);
            }
        }
    }
    public void ResetTimer()
    {
        addSpeedImg.fillAmount = 1;
    }
}
