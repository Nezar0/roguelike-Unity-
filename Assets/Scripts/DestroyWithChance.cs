using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithChance : MonoBehaviour
{
    [Range(0, 1)]
    public float ChanceOfStaing = 0.5f;
    void Start()
    {
        if (Random.value > ChanceOfStaing) Destroy(gameObject);
    }
}
