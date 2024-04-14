using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        Vector3 enemyPosition = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false) {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator CreateEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
