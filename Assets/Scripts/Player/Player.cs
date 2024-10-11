using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public Pause_Menu pause;
    public Rigidbody2D rb;
    public Animator animator;
    public int health = 100;
    public int totalBattlePoints = 0;
    public int elfDamageBattlePoints = 25;
    public int elfDeathBattlePoints = 50;
    public float moveSpeed = 35f;
    public GameObject deathEffect;
    public float minDistance = 5f;
    public float range;

    //lighting
    public GameObject cigarLight1;
    public GameObject cigarLight2;

    //jumping
    public float jumpHeight;
    public bool isJumping;
    public GameObject jumpFX;
    public bool hasTouchedGround;

    //levelBeating
    public bool levelBeat = false;
    public float killCount = 0;
    public float killsToWin; //Set this in the editor for every level (it should be the exact number of enemies that will be featured in the level)

    //UI
    public GameObject canvas;
    public GameObject levelSystemCanvas;
    public GameObject deathMenu;

    Vector2 movement;

    public void Awake()
    {
        canvas.SetActive(true);

        cigarLight2.SetActive(false);
    }

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        //movement
        movement.x = Input.GetAxisRaw("Horizontal");

        //jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
        }

        //animator stuff
        animator.SetBool("idleRight", Mathf.Abs(moveSpeed) > .01f);
        animator.SetBool("idleLeft", Mathf.Abs(moveSpeed) < .01f);

        if (animator.GetFloat("Horizontal") >= .1)
        {
            animator.SetBool("idleRight", true);
            animator.SetBool("idleLeft", false);
        }

        if (animator.GetFloat("Horizontal") < 1)
        {
            animator.SetBool("idleLeft", true);
            animator.SetBool("idleRight", false);
        }

        if(animator.GetFloat("Horizontal") >= 1)
        {
            cigarLight1.SetActive(true);
            cigarLight2.SetActive(false);
        }

        if (animator.GetFloat("Horizontal") < 0)
        {
            cigarLight1.SetActive(false);
            cigarLight2.SetActive(true);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //levelSystem
        if (killCount >= killsToWin)
        {
            levelBeat = true;
        }

        if(levelBeat == true)
        {
            levelSystemCanvas.SetActive(true);
            Destroy(pause.pauseMenu);
        }

        //jumping
        if (isJumping && hasTouchedGround)
        {
            StartCoroutine(JumpFxTimer());
            int rand = UnityEngine.Random.Range(0, 16);
            if (rand == 0)
            {
                ShakeCinemachine.Instance.ShakeCamera(10f, .1f);
            }
            else if (rand == 0)
            {
                ShakeCinemachine.Instance.ShakeCamera(11f, .1f);
            }
            else if (rand == 1)
            {
                ShakeCinemachine.Instance.ShakeCamera(12f, .1f);
            }
            else if (rand == 2)
            {
                ShakeCinemachine.Instance.ShakeCamera(13f, .1f);
            }
            else if (rand == 3)
            {
                ShakeCinemachine.Instance.ShakeCamera(14f, .1f);
            }
            else if (rand == 4)
            {
                ShakeCinemachine.Instance.ShakeCamera(15f, .1f);
            }
            else if (rand == 5)
            {
                ShakeCinemachine.Instance.ShakeCamera(16f, .1f);
            }
            else if (rand == 6)
            {
                ShakeCinemachine.Instance.ShakeCamera(9f, .1f);
            }
            else if (rand == 7)
            {
                ShakeCinemachine.Instance.ShakeCamera(8f, .1f);
            }
            else if (rand == 8)
            {
                ShakeCinemachine.Instance.ShakeCamera(7f, .1f);
            }
            else if (rand == 9)
            {
                ShakeCinemachine.Instance.ShakeCamera(5f, .1f);
            }
            else if (rand == 10)
            {
                ShakeCinemachine.Instance.ShakeCamera(6f, .1f);
            }
            else if (rand == 11)
            {
                ShakeCinemachine.Instance.ShakeCamera(17f, .1f);
            }
            else if (rand == 12)
            {
                ShakeCinemachine.Instance.ShakeCamera(18f, .1f);
            }
            else if (rand == 13)
            {
                ShakeCinemachine.Instance.ShakeCamera(19f, .1f);
            }
            else if (rand == 14)
            {
                ShakeCinemachine.Instance.ShakeCamera(20f, .1f);
            }
            else if (rand == 15)
            {
                ShakeCinemachine.Instance.ShakeCamera(21f, .1f);
            }
        }
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //jumping
        if (isJumping && hasTouchedGround)
        {
            StartCoroutine(JumpFxTimer());
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Force);
            StartCoroutine(JumpingTimer());
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("border"))
        {
                StartCoroutine(JumpFxTimer());
                int rand = UnityEngine.Random.Range(0, 16);
                if (rand == 0)
                {
                    ShakeCinemachine.Instance.ShakeCamera(10f, .1f);
                }
                else if (rand == 0)
                {
                    ShakeCinemachine.Instance.ShakeCamera(11f, .1f);
                }
                else if (rand == 1)
                {
                    ShakeCinemachine.Instance.ShakeCamera(12f, .1f);
                }
                else if (rand == 2)
                {
                    ShakeCinemachine.Instance.ShakeCamera(13f, .1f);
                }
                else if (rand == 3)
                {
                    ShakeCinemachine.Instance.ShakeCamera(14f, .1f);
                }
                else if (rand == 4)
                {
                    ShakeCinemachine.Instance.ShakeCamera(15f, .1f);
                }
                else if (rand == 5)
                {
                    ShakeCinemachine.Instance.ShakeCamera(16f, .1f);
                }
                else if (rand == 6)
                {
                    ShakeCinemachine.Instance.ShakeCamera(9f, .1f);
                }
                else if (rand == 7)
                {
                    ShakeCinemachine.Instance.ShakeCamera(8f, .1f);
                }
                else if (rand == 8)
                {
                    ShakeCinemachine.Instance.ShakeCamera(7f, .1f);
                }
                else if (rand == 9)
                {
                    ShakeCinemachine.Instance.ShakeCamera(5f, .1f);
                }
                else if (rand == 10)
                {
                    ShakeCinemachine.Instance.ShakeCamera(6f, .1f);
                }
                else if (rand == 11)
                {
                    ShakeCinemachine.Instance.ShakeCamera(17f, .1f);
                }
                else if (rand == 12)
                {
                    ShakeCinemachine.Instance.ShakeCamera(18f, .1f);
                }
                else if (rand == 13)
                {
                    ShakeCinemachine.Instance.ShakeCamera(19f, .1f);
                }
                else if (rand == 14)
                {
                    ShakeCinemachine.Instance.ShakeCamera(20f, .1f);
                }
                else if (rand == 15)
                {
                    ShakeCinemachine.Instance.ShakeCamera(21f, .1f);
                }
            hasTouchedGround = true;
            isJumping = false;
        }
    }

    public IEnumerator JumpingTimer()
    {
       rb.GetComponent<BoxCollider2D>().enabled = false;
       yield return new WaitForSeconds(.5f);
       hasTouchedGround = false;
       rb.GetComponent<BoxCollider2D>().enabled = true;
    }

    public IEnumerator JumpFxTimer()
    {
        jumpFX.SetActive(true);
        yield return new WaitForSeconds(.5f);
        jumpFX.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        int rand = UnityEngine.Random.Range(0, 16);
        if (rand == 0)
        {
            ShakeCinemachine.Instance.ShakeCamera(10f, .1f);
        }
        else if (rand == 0)
        {
            ShakeCinemachine.Instance.ShakeCamera(11f, .1f);
        }
        else if (rand == 1)
        {
            ShakeCinemachine.Instance.ShakeCamera(12f, .1f);
        }
        else if (rand == 2)
        {
            ShakeCinemachine.Instance.ShakeCamera(13f, .1f);
        }
        else if (rand == 3)
        {
            ShakeCinemachine.Instance.ShakeCamera(14f, .1f);
        }
        else if (rand == 4)
        {
            ShakeCinemachine.Instance.ShakeCamera(15f, .1f);
        }
        else if (rand == 5)
        {
            ShakeCinemachine.Instance.ShakeCamera(16f, .1f);
        }
        else if (rand == 6)
        {
            ShakeCinemachine.Instance.ShakeCamera(9f, .1f);
        }
        else if (rand == 7)
        {
            ShakeCinemachine.Instance.ShakeCamera(8f, .1f);
        }
        else if (rand == 8)
        {
            ShakeCinemachine.Instance.ShakeCamera(7f, .1f);
        }
        else if (rand == 9)
        {
            ShakeCinemachine.Instance.ShakeCamera(5f, .1f);
        }
        else if (rand == 10)
        {
            ShakeCinemachine.Instance.ShakeCamera(6f, .1f);
        }
        else if (rand == 11)
        {
            ShakeCinemachine.Instance.ShakeCamera(17f, .1f);
        }
        else if (rand == 12)
        {
            ShakeCinemachine.Instance.ShakeCamera(18f, .1f);
        }
        else if (rand == 13)
        {
            ShakeCinemachine.Instance.ShakeCamera(19f, .1f);
        }
        else if (rand == 14)
        {
            ShakeCinemachine.Instance.ShakeCamera(20f, .1f);
        }
        else if (rand == 15)
        {
            ShakeCinemachine.Instance.ShakeCamera(21f, .1f);
        }
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void GainDamageBattlePoints(int elfDamageBattlePoints)
    {
        totalBattlePoints += elfDamageBattlePoints;
    }

    public void GainDeathBattlePoints(int elfDeathBattlePoints)
    {
        totalBattlePoints += elfDeathBattlePoints;
    }

    public void GainDeerDamageBattlePoints(int deerDamageBattlePoints)
    {
        totalBattlePoints += deerDamageBattlePoints;
    }

    public void GainDeerDeathBattlePoints(int deerDeathBattlePoints)
    {
        totalBattlePoints += deerDeathBattlePoints;
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        deathMenu.SetActive(true);
    }

    internal void GainDeathBattlePoints(object elfDeathBattlePoints)
    {
        throw new NotImplementedException();
    }
}
