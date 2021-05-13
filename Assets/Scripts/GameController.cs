using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{   
    [SerializeField]
    private GameObject player;

    public enum TypeWeapon { sword, bow }
    public TypeWeapon weapon;

    [Header("Diffculty")]
    public AnimationCurve diffcultyFromDungeonsCom;
    public static GameController Instance { get; private set; }

    private static float diffculty;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += LoadingOnScene;
    }

    void LoadingOnScene(Scene scene, LoadSceneMode mode)
    {
        diffculty = diffcultyFromDungeonsCom.Evaluate(DungeonsComplited.Count);
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (weapon == TypeWeapon.sword)
        {
            ChoiceSword();
        }
        else if (weapon == TypeWeapon.bow)
        {
            ChoiceBow();
        }
    }

    
    public void ChoiceSword()
    {
        player.GetComponent<PlayerAttack>().enabled = true;
        player.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void ChoiceBow()
    {
        player.GetComponent<PlayerAttack>().enabled = false;
        player.transform.GetChild(1).gameObject.SetActive(true);
    }

    public static float Diffculty()
    {
        float diff = diffculty;
        return diff + 1;
    }
}
