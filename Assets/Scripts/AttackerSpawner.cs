using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker[] enemyPrefabs;
    [SerializeField] float startWaitTime = 3f;
    bool spawn = true;

    float defaultDifficulty = 1f;

    private void Awake()
    {
        int difficulty = PlayerPrefsController.GetDifficulty(defaultDifficulty);
        switch (difficulty)
        {
            case 1:
                minSpawnTime += 2f;
                maxSpawnTime += 2f;
                startWaitTime /= 4f;
                break;
            case 2:
                minSpawnTime += 1f;
                maxSpawnTime += 1f;
                startWaitTime /= 2f;
                break;
            default:
                break;
        }
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(startWaitTime);
        while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnEnemy()
    {
        var attackerIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        Spawn(enemyPrefabs[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
