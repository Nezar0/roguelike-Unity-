using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Training : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private PlayerMovement movement;
    [SerializeField]
    private GameObject moveZone;
    [SerializeField]
    private GameObject attackZone;


    [SerializeField] private GameObject Dummy;
    [SerializeField] private GameObject Table;
    [SerializeField] private Image bowImg;


    [Header("текс диалога")]
    [SerializeField]
    private TutorialDialog dialog;
    [SerializeField]
    private Text textDialog;
    private Queue<string> sentences;
    private int sentencesCount;
    [SerializeField]
    private GameObject endPanel;
    void Start()
    {
        sentences = new Queue<string>();
        movement = player.GetComponent<PlayerMovement>();

        StartDialog(dialog);
        sentencesCount = sentences.Count;
    }
    void Update()
    {
        if (movement.joystick.Horizontal != 0 && sentences.Count == sentencesCount)
        {
            Destroy(moveZone);
            NextDialog();
            Dummy.SetActive(true);
            attackZone.SetActive(true);
        }
        if(player.GetComponent<PlayerAttack>().joystick.Horizontal != 0 && sentences.Count == sentencesCount - 1 && Dummy.GetComponent<EnemyHealth>().health < Dummy.GetComponent<EnemyHealth>().maxHealth)
        {
            Destroy(attackZone);
            NextDialog();
            Table.SetActive(true);
        }
        if(bowImg.gameObject.activeSelf == true)
        {
            EndDialog();
        }
    }


    public void StartDialog(TutorialDialog dialog)
    {
        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextDialog();
    }

    public void NextDialog()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        textDialog.text = sentence;
    }

    public void EndDialog()
    {
        gameObject.GetComponent<Canvas>().sortingOrder = 10;
        endPanel.SetActive(true);
        textDialog.text = "";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ClosePanel()
    {
        SceneManager.LoadScene("SafeLocation");
    }
}
