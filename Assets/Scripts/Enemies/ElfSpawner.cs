using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfSpawner : MonoBehaviour
{
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;

    public GameObject elfPrefab;
    public int enemyCount1;
    public int enemyCount2;
    public int enemyCount3; //the enemy count for the spawners close to the player.

    public bool spawningDone = false;

    public void Start()
    {
        StartCoroutine(EnemySpawnDrop1());
        StartCoroutine(EnemySpawnDrop2());
        StartCoroutine(EnemySpawnDrop3());
        StartCoroutine(EnemySpawnDrop4());
    }

    public void Update()
    {
        if (enemyCount1 == 25 && enemyCount2 == 25)
        {
            spawningDone = true;
        }
    }

    IEnumerator EnemySpawnDrop1()
    {
        while (enemyCount1 < 25)
        {
            Instantiate(elfPrefab, spawner1.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount1 += 1;
        }
    }

    IEnumerator EnemySpawnDrop2()
    {
        while (enemyCount2 < 25)
        {
            Instantiate(elfPrefab, spawner2.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount2 += 1;
        }
    }

    IEnumerator EnemySpawnDrop3()
    {
        while (enemyCount2 < 1)
        {
            Instantiate(elfPrefab, spawner3.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount2 += 1;
        }
    }

    IEnumerator EnemySpawnDrop4()
    {
        while (enemyCount2 < 1)
        {
            Instantiate(elfPrefab, spawner4.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount2 += 1;
        }
    }
}
