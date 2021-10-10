using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    int currentHitPoints = 0;

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
        }
    }
}
