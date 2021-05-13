using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform player;
    public Slider healthBar;

    public float speed = 1f;

    public float attackTime;
    public float startTimeAttack;
    public int damage;

    [SerializeField]
    private GameObject nextLevel;

    private int faceRight = 1;
    void Start()
    {
        healthBar.maxValue = GetComponentInParent<EnemyHealth>().health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime));

        if (GetComponent<EnemyHealth>().health <= 25)
        {
            anim.SetTrigger("stageTwo");
        }

        if (GetComponent<EnemyHealth>().health <= 0)
        {
            Instantiate(nextLevel, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
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

        healthBar.value = GetComponent<EnemyHealth>().health;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (attackTime <= 0)
            {
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
        attackTime = startTimeAttack;
        anim.SetBool("isAttacking", false);
    }
}
