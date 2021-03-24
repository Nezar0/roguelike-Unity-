using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform player;

    public float speed = 1f;

    private int faceRight = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime));

        if (player.position.x < rb.position.x)
        {
            sr.flipX = true;
            faceRight *= -1;
        }
        else
        {
            faceRight *= -1;
            sr.flipX = false;
        }
    }
}
