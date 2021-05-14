using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform player;

    public HealthBar healthBar;

    public float speed = 1f;

    public float attackTime;
    public float startTimeAttack;
    public int damage;
    public float stopTime;
    public float startStopTime;
    private float normalSpeed;

    private int faceRight = 1;
    private RoomController enemyList;
    void Start()
    {
        healthBar.SetHealth(GetComponent<EnemyHealth>().health, GetComponent<EnemyHealth>().maxHealth);
        normalSpeed = speed;
        enemyList = GetComponentInParent<RoomController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime));

        if (GetComponent<EnemyHealth>().health <= 0)
        {
            Destroy(gameObject);
            enemyList.enemis.Remove(gameObject);           
        }

        if(stopTime <=0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
      
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
        healthBar.SetHealth(GetComponent<EnemyHealth>().health, GetComponent<EnemyHealth>().maxHealth);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {        
            if (attackTime <= 0)
            {
                attackTime = startTimeAttack;
                stopTime = startStopTime;
                anim.SetBool("isAttacking", true);
            }
            else
            {
                attackTime -= Time.deltaTime;
            }
        }
    }

    public void OnAttack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        anim.SetBool("isAttacking", false);
    }
}
