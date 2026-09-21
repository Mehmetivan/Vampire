//using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy enemyToSpawn;
    [SerializeField] Transform player;

    //[SerializeField] playerHealth health;

    float nextSpawn = 0;

    [Range(1f, 100.0f)]
    [SerializeField] float SpawnRate;
    List<Enemy> enemyList = new();

    private void Update()
    {
        nextSpawn += SpawnRate * Time.deltaTime;
        if (nextSpawn >= 1)
        {
            SpawnCube();
            nextSpawn = 0; 
        }

    }

    public void SpawnCube()
    {
        Vector2 randomPosition = Vector2.zero;

        randomPosition.x = Random.Range(-5,5);
        randomPosition.y = Random.Range(-5,5);

        Enemy newEnemy = Instantiate(enemyToSpawn, randomPosition, Quaternion.identity);

        newEnemy.SetTarget(player);
        //newEnemy.SetPlayerHealth(health);

        enemyList.Add(newEnemy);
    }


}

