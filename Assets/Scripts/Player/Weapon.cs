using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform playerPosition;
    public GameObject bulletPrefab;
    public GameObject bigBulletPrefab;
    public GameObject muzzleFlash;
    public GameObject poundFX;
    public GameObject muzzleBlast;
    public GameObject healthFX;
    public GameObject doubleFX;
    public GameObject poundFxAnim;
    public Animator anim;
    public bool bigBullet;
    public bool facingRight = false;
    public int damage = 5000;
    public Bullet bullet;
    public GameObject bombPrefab;

    public Player player;

    //pound
    public float fieldOfImpact;
    public float force;
    public LayerMask LayerToHit;

    //ability boxes
    public GameObject healthBoostBox;
    public GameObject bombSpawnBox;
    public GameObject doubleDamageBox;
    public GameObject poundSpawnBox;
    public Button bombBtn;
    public Button damageBtn;
    public Button healthBtn;
    public Button poundBtn;


    public void Awake()
    {
        muzzleFlash.SetActive(false);
        poundFX.SetActive(false);
    }

    // Update is called once per frame
    [System.Obsolete]
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Space
            Shoot();
        }

        //pound
        if (player.totalBattlePoints >= 3500)
        {
            //n
            if (Input.GetButtonDown("Fire6"))
            {
                player.totalBattlePoints -= 3500;
                ShakeCinemachine.Instance.ShakeCamera(65f, .8f);
                StartCoroutine(Pound());
                PoundExplosion();
                StartCoroutine(PoundBox());
            }
        }

        //healthBoost
        if (player.totalBattlePoints >= 2000)
        {
            //x
            if (Input.GetButtonDown("Fire3"))
            {
                player.health += 150;
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
                player.totalBattlePoints -= 2000;
                StartCoroutine(HealthFX());
                StartCoroutine(HealthBox());
            }
        }

        //double damage
        if (player.totalBattlePoints >= 1500)
        {
            //z
            if (Input.GetButtonDown("Fire4"))
            {
                StartCoroutine(DoubleDamage());
                player.totalBattlePoints -= 1500;
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
                StartCoroutine(DoubleFX());
                StartCoroutine(DoubleBox());
            }
        }

        //bomb
        if (player.totalBattlePoints >= 1200)
        {
            //b
            if (Input.GetButtonDown("Fire5"))
            {
                player.totalBattlePoints -= 1200;

                Instantiate(bombPrefab, playerPosition.position, playerPosition.rotation);
                StartCoroutine(BombBox());
            }
        }

        //ability boxes
        if (player.totalBattlePoints < 1500)
        {
            damageBtn.interactable = false;
        }
        else if(player.totalBattlePoints >= 1500)
        {
            damageBtn.interactable = true;
        }
        if (player.totalBattlePoints < 2000)
        {
            healthBtn.interactable = false;
        }
        else if(player.totalBattlePoints >= 2000)
        {
            healthBtn.interactable = true;
        }
        if (player.totalBattlePoints < 1200)
        {
            bombBtn.interactable = false;
        }
        else if(player.totalBattlePoints >= 1200)
        {
            bombBtn.interactable = true;
        }
        if (player.totalBattlePoints < 3500)
        {
            poundBtn.interactable = false;
        }
        else if (player.totalBattlePoints >= 3500)
        {
            poundBtn.interactable = true;
        }
    }

    [System.Obsolete]
    void Shoot()
    {
        StartCoroutine(Flash());
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
        Instantiate(muzzleBlast, firePoint.position, firePoint.rotation);
        if(bigBullet == true)
        {
            Instantiate(bigBulletPrefab, firePoint.position, firePoint.rotation);
        }
        else if (bigBullet == false)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    IEnumerator Pound()
    {
        anim.SetBool("isPounding", true);
        poundFX.SetActive(true);
        poundFxAnim.SetActive(true);
        yield return new WaitForSeconds(1f);
        poundFxAnim.SetActive(false);
        anim.SetBool("isPounding", false);
        poundFX.SetActive(false);
    }

    IEnumerator DoubleFX()
    {
        doubleFX.SetActive(true);
        yield return new WaitForSeconds(2f);
        doubleFX.SetActive(false);
    }

    IEnumerator HealthFX()
    {
        healthFX.SetActive(true);
        yield return new WaitForSeconds(2f);
        healthFX.SetActive(false);
    }

    void PoundExplosion()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);

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

            zombieElf enemy = obj.GetComponent<zombieElf>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

    [System.Obsolete]
    IEnumerator Flash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.05f);
        muzzleFlash.SetActive(false);
    }

    IEnumerator DoubleDamage()
    {
        bullet.damage = 80;
        bigBullet = true;
        yield return new WaitForSeconds(15f);
        bigBullet = false;
        bullet.damage = 40;
    }

    IEnumerator DoubleBox()
    {
        damageBtn.interactable = false;
        yield return new WaitForSeconds(15f);
        if (player.totalBattlePoints < 1500)
        {
            damageBtn.interactable = false;
        }
        else if (player.totalBattlePoints >= 1500)
        {
            damageBtn.interactable = true;
        }
    }

    IEnumerator HealthBox()
    {
        healthBtn.interactable = false;
        yield return new WaitForSeconds(8f);
       if (player.totalBattlePoints < 3500)
        {
            healthBtn.interactable = false;
        }
        else if (player.totalBattlePoints >= 3500)
        {
            healthBtn.interactable = true;
        }
    }

    IEnumerator BombBox()
    {
        bombBtn.interactable = false;
        yield return new WaitForSeconds(2f);
        if (player.totalBattlePoints >= 1200)
        {
            bombBtn.interactable = true;
        }
        else if (player.totalBattlePoints < 3500)
        {
            bombBtn.interactable = false;
        }
    }

    IEnumerator PoundBox()
    {
        yield return new WaitForSeconds(1f);
        
        if (player.totalBattlePoints >= 3500)
        {
            poundBtn.interactable = true;
        }
        else if (player.totalBattlePoints < 3500)
        {
            poundBtn.interactable = false;
        }
    }
}