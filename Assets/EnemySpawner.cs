//using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IUpdateable
{

    [SerializeField] Enemy enemyToSpawn;

    [SerializeField] Bat bat;
    [SerializeField] Transform player;

    //[SerializeField] playerHealth health;

    float nextSpawn = 0;
    float BatSpawn = 0;

    [Range(1f, 100.0f)]
    [SerializeField] float SpawnRate;
    List<Enemy> enemyList = new();
    List<Bat> batList = new();



    private void OnEnable()
    {
        GameUpdateManager.Instance.Register(this, UpdatePriority.High);

    }
    private void OnDisable()
    {
        GameUpdateManager.Instance.Unregister(this);

    }

    public void OnUpdate(float deltaTime) {
        nextSpawn += SpawnRate * deltaTime;
        BatSpawn += SpawnRate * deltaTime;

        if (nextSpawn >= 1)
        {
            SpawnCube();
            nextSpawn = 0;
        }
        if (BatSpawn >= 4)
        {
            SpawnBat();
            BatSpawn = 0;
        }

        //search a better way to remove enemies from the list when they are destroyed
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
            }
        }

        for (int i = batList.Count - 1; i >= 0; i--)
        {
            if (batList[i] == null)
            {
                batList.RemoveAt(i);
            }
        }

    }

    public void SpawnCube()
    {
        Vector2 randomPosition = Vector2.zero;

        randomPosition.x = Random.Range(-5,5);
        randomPosition.y = Random.Range(-5,5);

        Enemy newEnemy = Instantiate(enemyToSpawn, randomPosition, Quaternion.identity);

        newEnemy.SetTarget(player);

        var um = UpgradeManager.Instance;
        newEnemy.GetComponent<EnemyStats>().ApplyScaling(
            um.EnemySpeedMultiplier,
            um.EnemyHealthMultiplier,
            um.EnemyDamageMultiplier);
        //newEnemy.SetPlayerHealth(health);

        enemyList.Add(newEnemy);
    }

    public void SpawnBat()
    {
        Vector2 randomPosition = Vector2.zero;
        randomPosition.x = Random.Range(-5, 5);
        randomPosition.y = Random.Range(-5, 5);
        Bat newBat = Instantiate(bat, randomPosition, Quaternion.identity);
        newBat.SetTarget(player);
        var um = UpgradeManager.Instance;
        newBat.GetComponent<EnemyStats>().ApplyScaling(
            um.EnemySpeedMultiplier,
            um.EnemyHealthMultiplier,
            um.EnemyDamageMultiplier);
        //newEnemy.SetPlayerHealth(health);
        batList.Add(newBat);
    }


}

