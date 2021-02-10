using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
    public Dir dir;
    public enum Dir
    {
        Up,
        Dowm,
        Right,
        Left,
        None
    }

    private RoomsOptions options;
    private int rand;
    public bool spawned = false;
    private float waitTime = 3f;   

    private void Start()
    {
        options = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsOptions>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    }
    public void Spawn()
    {
        if (!spawned && RoomCount.Count < 10)
        {
            if (dir == Dir.Up)
            {
                rand = Random.Range(0, options.upRooms.Length);
                Instantiate(options.upRooms[rand], transform.position, options.upRooms[rand].transform.rotation);
            }
            else if (dir == Dir.Dowm)
            {
                rand = Random.Range(0, options.downRooms.Length);
                Instantiate(options.downRooms[rand], transform.position, options.downRooms[rand].transform.rotation);
            }
            else if (dir == Dir.Right)
            {
                rand = Random.Range(0, options.rightRooms.Length);
                Instantiate(options.rightRooms[rand], transform.position, options.rightRooms[rand].transform.rotation);
            }
            else if (dir == Dir.Left)
            {
                rand = Random.Range(0, options.leftRooms.Length);
                Instantiate(options.leftRooms[rand], transform.position, options.leftRooms[rand].transform.rotation);
            }
            RoomCount.Count++;
            spawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint"))
        {
            Destroy(gameObject);
        }            
    }
}
