using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 30f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;

    // Start is called before the first frame update
    public void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        zombieElf enemy = hitInfo.GetComponent<zombieElf>();
        Deer deerEnemy = hitInfo.GetComponent<Deer>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (deerEnemy != null)
        {
            deerEnemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
