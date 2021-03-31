using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Joystick joystick;
    private float attackTime;
    public float startTimeAttack;
    public int damage = 5;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask enemies;

    private Animator anim;
    private float deg;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {    
        deg = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        if(joystick.Horizontal < -0.1)
        {
            gameObject.transform.localScale = new Vector3(-6.25f, 6.25f, 1);
        }
        else if (joystick.Horizontal > 0.1)
        {
            gameObject.transform.localScale = new Vector3(6.25f, 6.25f, 1);
        }
        if(attackTime <= 0)
        {
            if (deg != 0)
            {
                anim.SetBool("isAttacking", true);
                
                if (deg <= 120 && deg > 60) //up
                {
                    anim.SetInteger("Deg", 1);
                }
                if (deg <= 60 && deg > -60 || deg > 120 && deg >= -120) //side
                {
                    anim.SetInteger("Deg", 2);
                }
                if (deg > -120 && deg <= -60)// down
                {
                    anim.SetInteger("Deg", 3);
                }
                attackTime = startTimeAttack;
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
            anim.SetBool("isAttacking", false);           
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

    public void OnAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemies);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
