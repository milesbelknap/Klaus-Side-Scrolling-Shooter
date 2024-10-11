using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 150;
    public Animator anim;
    public GameObject bombFX;
    public GameObject bomb;
    public GameObject text;

    //bomb
    public float fieldOfImpact;
    public float force;
    public LayerMask LayerToHit;
    public GameObject muzzleFlash;


    public void Awake()
    {
        bombFX.SetActive(false);
    }
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(FXTimer());
        StartCoroutine(BombTimer());
    }

    IEnumerator BombTimer()
    {
        anim.SetBool("Bomb_Countdown", true);
        yield return new WaitForSeconds(3f);
        ShakeCinemachine.Instance.ShakeCamera(45f, .8f);
        BombExplosion();
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    IEnumerator Flash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.8f);
        muzzleFlash.SetActive(false);
    }

    IEnumerator FXTimer()
    {
        yield return new WaitForSeconds(3);
        bombFX.SetActive(true);
    }

    void BombExplosion()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        StartCoroutine(Flash());

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);


            zombieElf enemy = obj.GetComponent<zombieElf>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        bomb.GetComponent<SpriteRenderer>().enabled = false;
        text.GetComponent<SpriteRenderer>().enabled = false;
    }
}
