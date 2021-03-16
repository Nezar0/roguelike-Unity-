using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRandomItem : MonoBehaviour
{
    public Sprite[] walls;
    public Sprite[] floors;

    private void Start()
    {
        foreach(var filter in GetComponentsInChildren<SpriteRenderer>())
        {
            if(filter.sprite == walls[0])
            {
                filter.sprite = walls[Random.Range(0, walls.Length)];
            }

            if (filter.sprite == floors[0])
            {
                filter.sprite = floors[Random.Range(0, floors.Length)];
                filter.transform.rotation = Quaternion.Euler(0,0, 90 * Random.Range(0, 4));
            }
        }
    }
}
