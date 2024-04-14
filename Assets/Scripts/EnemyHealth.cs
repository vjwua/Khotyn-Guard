using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] public int diffcultyRamp = 1;
    
    int currentPoints = 0;
    Enemy enemy;

    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    void OnEnable()
    {
        currentPoints = maxHitPoints; 
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentPoints--;
        if (currentPoints < 1) KillEnemy();
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
        maxHitPoints += diffcultyRamp;
        enemy.RewardGold();
    }
}
