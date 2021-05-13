using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button btnContinue;
    private void Start()
    {
        if(!ES3.FileExists())
        {
            btnContinue.interactable = false;
        }
    }
    public void OnPlayNewGame()
    {        
        SceneManager.LoadScene("SafeLocation");
    }
    public void OnPlayGame()
    {
        DungeonsComplited.Count = ES3.Load("DungeonsComplited.Count", DungeonsComplited.Count);
        SceneManager.LoadScene("SafeLocation");
    }
    public void OnExit()
    {
        Application.Quit();
    }
}
