using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 5f;
    [Tooltip("Uses deaths to increas health")]
    [SerializeField] float deaths = 0f;
    float currentHitPoints = 0f;

    Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    // removes lives and deactivates enemies when dead
    void ProcessHit()
    {
        currentHitPoints -= 1;
        if (currentHitPoints < 1)
        {
            deaths += 1;
            if (deaths >= 5)
            {
                maxHitPoints = Mathf.Log(Mathf.Pow(deaths, 5)) + Mathf.Sqrt(deaths);
            }
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
