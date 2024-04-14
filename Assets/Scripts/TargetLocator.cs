using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float shootRange = 15f;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        if(target == null) { return; }
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        weapon.LookAt(target);

        if (targetDistance < shootRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool IsActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = IsActive;
    }
}
