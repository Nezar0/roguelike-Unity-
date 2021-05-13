using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
	public GameObject panel;
	public void OnPauseGame()
    {
		Time.timeScale = 0;
		panel.SetActive(true);
	}

	public void OnUnpauseGame()
	{
		Time.timeScale = 1;
		panel.SetActive(false);
	}
	public void BtnMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}
	private void OnApplicationPause(bool pause)
    {
		Debug.Log(pause);
        if (pause)
        {
			OnPauseGame();
		}
    }
}