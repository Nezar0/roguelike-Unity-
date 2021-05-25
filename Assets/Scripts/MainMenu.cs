using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button btnContinue;
    [SerializeField]
    private GameObject panelConfTutorial;
    private void Start()
    {
        if(!ES3.FileExists())
        {
            btnContinue.interactable = false;
        }
    }
    public void OnPlayNewGame()
    {
        panelConfTutorial.SetActive(true);       
    }

    public void OnPlayNewGameWithNotTutorial()
    {
        SceneManager.LoadScene("SafeLocation");
    }
    public void OnPlayNewGameWithTutorial()
    {
        SceneManager.LoadScene("Tutorial");
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
