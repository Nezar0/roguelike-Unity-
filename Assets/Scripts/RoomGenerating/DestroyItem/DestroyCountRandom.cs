using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCountRandom : MonoBehaviour
{
    private int CountToLeave = 1;
    void Start()
    {
        CountToLeave = Random.Range(0, 5);
        while (transform.childCount > CountToLeave)
        {
            Transform children = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(children.gameObject);
        }
    }
}
