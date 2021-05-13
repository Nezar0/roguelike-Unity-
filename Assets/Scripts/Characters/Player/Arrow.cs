using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    [SerializeField]
    private bool enemy;

    private void Start()
    {
        Invoke("DestroArrow", lifeTime);
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("boss"))
            {
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            if (hit.collider.CompareTag("Player") && enemy)
            {
                hit.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            DestroArrow();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void DestroArrow()
    {
        Destroy(gameObject);
    }
}
