using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieElf : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float minDistance = 5f;
    public float range;
    public int damage = 5;
    public int health = 100;
    public float giveDamage;
    public bool dealDamage = false;
    public int elfDamageBattlePoints = 25;
    public int elfDeathBattlePoints = 50;

    //attacking
    public bool isEven = false;
    public GameObject deathEffect;
    public bool facingRight = false;
    public int killPoint = 1;

    public void Update()
    {
        range = Vector2.Distance(transform.position, player.position);

        if (range > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, -3), speed * Time.deltaTime);
        }

        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();
        if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player enemy = collision.gameObject.GetComponent<Player>();
        if (enemy != null)
        {
            var timeSpan = DateTime.Now;
            if (timeSpan.Second % .5 == 0)
            {
                if (isEven == false)
                {
                    //reduce health here
                    enemy.TakeDamage(damage);
                }
                isEven = true;
            }
            else
            {
                isEven = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Player enemy = collision.gameObject.GetComponent<Player>();
        if (enemy != null)
        {
            dealDamage = false;
        }
    
    }

    public void TakeDamage(int damage)
    {
        Player enemy = player.gameObject.GetComponent<Player>();
        enemy.GainDamageBattlePoints(elfDamageBattlePoints);
        health -= damage;

        if (health <= 0)
        {
            enemy.killCount += killPoint;
            Die();
        }
    }

    public void Die()
    {
        Player enemy = player.gameObject.GetComponent<Player>();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemy.GainDeathBattlePoints(elfDeathBattlePoints);
        Destroy(gameObject);
    }

    void Flip()
    {
        //here your flip function, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

}
