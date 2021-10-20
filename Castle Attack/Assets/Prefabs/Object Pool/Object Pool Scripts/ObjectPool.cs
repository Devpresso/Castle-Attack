using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("Enemy to Spawn")] [SerializeField] GameObject enemy;
    [Tooltip("Size of Maximum Enemies")] [SerializeField] [Range(0, 50)] int poolSize = 5;
    [Tooltip("Spawn Time Between Enemies")] [SerializeField] [Range(0.1f, 20)] float spawnTime = 1f;

    GameObject[] pool;

    void Awake()
    {
        FillPool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Main function for respawning enimes at the start
    IEnumerator EnemySpawn()
    {
        while (Application.isPlaying)
        {
            EnablePool();
            yield return new WaitForSeconds(spawnTime);
        }

    }

    // fills the pool with the enemies
    void FillPool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    // allows acitvating enemies in the coroutine
    void EnablePool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }

    }
}
