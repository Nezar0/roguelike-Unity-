using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoor : MonoBehaviour
{
    public GameObject wall;


    private void Start()
    {
        Invoke("Check", 1f);
    }

    private void Check()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        try
        {
            if (transform.tag == "Door_down" && hitDown.transform.tag == "Wall")
            {
                Destroy(transform.parent.gameObject);
                Instantiate(wall, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.45545f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.45545f, transform.position.z), Quaternion.identity);
            }
            else if (transform.tag == "Door_up" && hitUp.transform.tag == "Wall")
            {
                Destroy(transform.parent.gameObject);
                Instantiate(wall, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.361197f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.361197f, transform.position.z), Quaternion.identity);
            }
            else if (transform.tag == "Door_left" && hitLeft.transform.tag == "Wall")
            {
                Destroy(transform.parent.gameObject);
                Instantiate(wall, new Vector3(transform.position.x + 0.365595f, transform.position.y + 0.480232f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x + 0.365595f, transform.position.y - 0.480232f, transform.position.z), Quaternion.identity);
            }
            else if (transform.tag == "Door_right" && hitRight.transform.tag == "Wall")
            {
                Destroy(transform.parent.gameObject);
                Instantiate(wall, new Vector3(transform.position.x - 0.365595f, transform.position.y + 0.480232f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x - 0.365595f, transform.position.y - 0.480232f, transform.position.z), Quaternion.identity);
            }            
        }
        catch
        {
            Destroy(transform.parent.gameObject);
            if (transform.tag == "Door_up")
            {
                Instantiate(wall, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.361197f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.361197f, transform.position.z), Quaternion.identity);
            }
            if (transform.tag == "Door_down")
            {
                Instantiate(wall, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.45545f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.45545f, transform.position.z), Quaternion.identity);
            }
            if (transform.tag == "Door_left")
            {
                Instantiate(wall, new Vector3(transform.position.x + 0.365595f, transform.position.y + 0.480232f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x + 0.365595f, transform.position.y - 0.480232f, transform.position.z), Quaternion.identity);
            }
            if (transform.tag == "Door_right")
            {
                Instantiate(wall, new Vector3(transform.position.x - 0.365595f, transform.position.y + 0.480232f, transform.position.z), Quaternion.identity);
                Instantiate(wall, new Vector3(transform.position.x - 0.365595f, transform.position.y - 0.480232f, transform.position.z), Quaternion.identity);
            }
        }
    }
}
