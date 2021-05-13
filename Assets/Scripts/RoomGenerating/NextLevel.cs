using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void OnNextLevel()
    {
        RoomCount.Count = 1;
        if (Application.loadedLevelName == "SafeLocation")
        {          
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            ES3.Save("DungeonsComplited.Count", DungeonsComplited.Count);
            DungeonsComplited.Count++;
            SceneManager.LoadScene("SafeLocation");
        }
    }
}
