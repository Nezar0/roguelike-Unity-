using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsOptions : MonoBehaviour
{
    public GameObject[] upRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject key;
    public GameObject chest;
    public GameObject boss;

    [HideInInspector] public List<GameObject> rooms;

    Camera cam;
    Plane[] planes;

    private void Start()
    {
        cam = Camera.main;
        StartCoroutine(RandomSpawner());
    }

    private void Update()
    {
        if (boss != null)
        {
            planes = GeometryUtility.CalculateFrustumPlanes(cam);
            if (GeometryUtility.TestPlanesAABB(planes, boss.GetComponent<Collider2D>().bounds))
            {
                boss.gameObject.SetActive(true);
            }
            else
            {
                boss.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator RandomSpawner()
    {
        yield return new WaitForSeconds(3f);
        RoomController lastroom = rooms[rooms.Count - 1].GetComponent<RoomController>();
        int rand = Random.Range(1, rooms.Count - 2);

        Instantiate(key, rooms[rand].transform.position, Quaternion.identity);
        for (int i = 0; i < lastroom.doors.Length; i++)
        {
            if (lastroom.doors[i] == null)
                continue;     
            Destroy(lastroom.doors[i]);
            Instantiate(lastroom.closeDoor, lastroom.doors[i].transform.position, lastroom.doors[i].transform.rotation);
            boss = Instantiate(boss, lastroom.transform.position, Quaternion.identity);
        }       
    }
}
