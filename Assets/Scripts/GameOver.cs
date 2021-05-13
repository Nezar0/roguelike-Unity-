using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text textDungeonsCount;
    public Text textBestResult;
    public void BtnStartAgain()
    {
        SceneManager.LoadScene("SafeLocation");
        Time.timeScale = 1;
        DungeonsComplited.Count = 0;
    }
}
