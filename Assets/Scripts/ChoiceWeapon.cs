using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWeapon : MonoBehaviour
{
    public Image choiceBow;
    public Image choiceSword;

    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void ChoiceBow()
    {
        gameController.weapon = GameController.TypeWeapon.bow;
        choiceBow.gameObject.SetActive(true);
        choiceSword.gameObject.SetActive(false);
        gameController.ChoiceBow();
    }
    public void ChoiceSword()
    {
        gameController.weapon = GameController.TypeWeapon.sword;
        choiceBow.gameObject.SetActive(false);
        choiceSword.gameObject.SetActive(true);
        gameController.ChoiceSword();
    }
}
