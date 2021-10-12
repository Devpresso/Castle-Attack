using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    int currentHitPoints = 0;

    Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = hitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    // removes lives and deactivates enemies when dead
    void ProcessHit()
    {
        currentHitPoints -= 1;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
