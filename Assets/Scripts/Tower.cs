using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(gameObject, position, Quaternion.identity);
            bank.Withdrawal(cost);
            return true;
        }
        else
        {
            return false;
        }
    }
}
