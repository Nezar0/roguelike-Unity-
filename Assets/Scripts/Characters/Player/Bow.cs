using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public enum Type { Player,Enemy}
    public Type type;
    public Joystick joystick;
    public GameObject arrow;
    public Transform shotPoint;
    public float startTimeBtfShots;

    private float timeBtfShots;
    private float rotZ;

    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(type == Type.Player)
        {
            if (joystick.Horizontal < -0.1)
            {
                gameObject.transform.parent.localScale = new Vector3(-6.25f, 6.25f, 1);
                gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }
            else if (joystick.Horizontal > 0.1)
            {
                gameObject.transform.parent.localScale = new Vector3(6.25f, 6.25f, 1);
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
            if (Mathf.Abs(joystick.Horizontal) > 0.1f || Mathf.Abs(joystick.Horizontal) > 0.1f)
            {
                rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            }
        }
        else if (type == Type.Enemy)
        {
            Vector3 dif = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ );
        if (timeBtfShots <= 0)
        {
            if (type == Type.Enemy)
            {
                Shot();
            }
            else if(joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Shot();
            }
        }
        else
        {
            timeBtfShots -= Time.deltaTime;
        }
    }

    public void Shot()
    {
        Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        timeBtfShots = startTimeBtfShots;
    }
}
