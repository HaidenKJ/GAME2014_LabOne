using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    public GameObject enemyPrefab;
    public int poolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            pool.Enqueue(CreateEnemy());
        }
    }

    private GameObject CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform);
        enemy.SetActive(false);
        return enemy;
    }

    public GameObject Get()
    {
        // grow the pool only if it runs empty
        GameObject enemy = pool.Count > 0 ? pool.Dequeue() : CreateEnemy();
        enemy.SetActive(true);
        return enemy;
    }

    public void Return(GameObject enemy)
    {
        enemy.SetActive(false);
        pool.Enqueue(enemy);
    }
}