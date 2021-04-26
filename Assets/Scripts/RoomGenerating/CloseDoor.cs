using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_down") || collision.CompareTag("Door_right") || collision.CompareTag("Door_up") || collision.CompareTag("Door_left"))
        {
            Destroy(collision);
            Instantiate(gameObject, collision.transform.position, collision.transform.rotation);
        }
    }
}
