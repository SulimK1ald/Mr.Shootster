using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform spawnEnemyPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (Enemy != null)
        {
            Instantiate(Enemy, spawnEnemyPos.position, spawnEnemyPos.rotation);
        }
    }
}
