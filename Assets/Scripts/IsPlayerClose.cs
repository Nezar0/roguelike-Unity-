using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerClose : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
