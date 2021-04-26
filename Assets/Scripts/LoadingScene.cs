using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public void Loading()
    {
        ES3AutoSaveMgr.Current.Load();
    }
    public void Saveing()
    {
        ES3AutoSaveMgr.Current.Save();
    }
}
