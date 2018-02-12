using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes { SmallRat, DeterminedRat };

public class EnemyManager {

    public int enemiesToSpawn = 5;
    public int waveCount = 0;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesToDestroy = new List<GameObject>();
    public Dictionary<EnemyTypes, GameObject> enemyDict = new Dictionary<EnemyTypes, GameObject>();
    public void IntitializeEnemies()
    {
        enemyDict.Add(EnemyTypes.SmallRat, Services.PrefabDB.SmallRat as GameObject);
        enemyDict.Add(EnemyTypes.DeterminedRat, Services.PrefabDB.DeterminedRat as GameObject);
        SpawnWave(enemiesToSpawn);
        Services.EventManager.Register<PlayerPoweredUp>(DebugStuff);
    }

    public void SpawnWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount * waveCount; i++)
        {
            float randomNum = Random.Range(0, 100);
            if (randomNum > 50) SpawnSmallRat();
            else SpawnDeterminedRat();
        }
        waveCount++;
    }

    public void DestroyEnemy(GameObject enemy)
    {
        Services.EventManager.Unregister<PlayerPoweredUp>(DebugStuff);
        enemies.Remove(enemy);
        GameObject.Destroy(enemy);
    }

    public void DebugStuff(GC.GameEvent e)
    {
        PlayerPoweredUp powerUp = e as PlayerPoweredUp;
        foreach (GameObject enemy in enemies)
        {
            Debug.Log("My name is " + enemy.gameObject.name + " and my target is " + powerUp.player.gameObject.name);
        }
    }

    public void SpawnSmallRat()
    {
        GameObject rat = GameObject.Instantiate(GetSmallRat(), GetSpawnPoint(), Quaternion.identity) as GameObject;
        enemies.Add(rat);
    }

    public void SpawnDeterminedRat()
    {
        GameObject rat = GameObject.Instantiate(GetDeterminedRat(), GetSpawnPoint(), Quaternion.identity) as GameObject;
        enemies.Add(rat);
    }

    public GameObject GetSmallRat()
    {
        GameObject smallRat = enemyDict[EnemyTypes.SmallRat];
        return smallRat;
    }

    public GameObject GetDeterminedRat()
    {
        GameObject determinedRat = enemyDict[EnemyTypes.DeterminedRat];
        return determinedRat;
    }

    public Vector3 GetSpawnPoint()
    {
        float xMod = Random.Range(-10, 10);
        return GameObject.Find("SpawnPoint").transform.position + new Vector3(xMod, 0, 0);
    }

    public void UpdateEnemy()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            enemies[i].GetComponent<EnemySandbox>().OnUpdate();
        }
        for (int i = enemiesToDestroy.Count; i < 0; i--)
        {
            DestroyEnemy(enemiesToDestroy[i]);
        }
        enemiesToDestroy.Clear();
        if (enemies.Count == 0) SpawnWave(enemiesToSpawn);
    }
}
