using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public Transform player;
    public Transform enemyPosition;
    public float minDistance = 5f;
    public float range;
    public float speed = 2f;
    public int damage = 45;
    public int health = 100;
    public float giveDamage;
    public bool dealDamage = false;
    public int deerDamageBattlePoints = 65;
    public int deerDeathBattlePoints = 100;

    //attacking
    public bool isEven = false;
    public GameObject deathEffect;
    public bool facingRight = false;
    public int killPoint = 1;

    //dash attack
    public int distVal = 35;
    public bool dashAttackShouldRun = false;
    public GameObject dashFX1;
    public GameObject dashFX2;

    //animation
    public Animator anim;

    public void Start()
    {
        StartCoroutine(DashAttack());
    }

    // Update is called once per frame
    public void Update()
    {
        range = Vector3.Distance(gameObject.transform.position, player.position);

        if (range > minDistance)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(player.position.x, gameObject.transform.position.y, -3), speed * Time.deltaTime);
        }

        if (Vector3.Distance(enemyPosition.position, player.position) < distVal)
        {
            dashAttackShouldRun = true;
        }
        else if (Vector3.Distance(enemyPosition.position, player.position) > distVal)
        {
            dashAttackShouldRun = false;
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
        enemy.GainDeerDamageBattlePoints(deerDamageBattlePoints);
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
        enemy.GainDeerDeathBattlePoints(deerDeathBattlePoints);
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

    public IEnumerator DeerDashFxTimer()
    {
        dashFX1.SetActive(true);
        dashFX2.SetActive(true);
        yield return new WaitForSeconds(.5f);
        dashFX1.SetActive(false);
        dashFX2.SetActive(false);
    }

    IEnumerator DashAttack()
    {
        while (true)
        {
            if (Vector3.Distance(enemyPosition.position, player.position) < distVal && dashAttackShouldRun == true)
            {
                speed = 0f;
                anim.Play("4_Legged");
                yield return new WaitForSeconds(2f);
                speed = 20f;
                anim.Play("Charging");
                StartCoroutine(DeerDashFxTimer());
                yield return new WaitForSeconds(4f);
                speed = 0f;
                anim.Play("4_Legged");
            }
            if (Vector3.Distance(enemyPosition.position, player.position) < distVal)
            {
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(DashAttack());
            }
            else if (Vector3.Distance(enemyPosition.position, player.position) > distVal)
            {
                yield return new WaitForSeconds(3f);
                speed = 2f;
                anim.Play("Moving");
                dashAttackShouldRun = false;
            }
        }
    }
}
