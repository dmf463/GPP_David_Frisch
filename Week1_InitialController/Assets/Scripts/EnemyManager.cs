using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes { SmallRat, DeterminedRat };

public class EnemyManager {
    /*
     * things I want my manager to do right now
     * spawn and destory enemies
     */
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesToDestroy = new List<GameObject>();
    public Dictionary<EnemyTypes, GameObject> enemyDict = new Dictionary<EnemyTypes, GameObject>();
    public void IntitializeEnemies()
    {
        enemyDict.Add(EnemyTypes.SmallRat, Services.PrefabDB.SmallRat as GameObject);
        enemyDict.Add(EnemyTypes.DeterminedRat, Services.PrefabDB.DeterminedRat as GameObject);
        for (int i = 0; i < 5; i++)
        {
            float randomNum = Random.Range(0, 100);
            if (randomNum > 50) SpawnSmallRat();
            else SpawnDeterminedRat();
        }
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
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        GameObject.Destroy(enemy);
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

    public Vector3 GetSpawnPoint()
    {
        float xMod = Random.Range(-2, 2);
        return GameObject.Find("SpawnPoint").transform.position + new Vector3(xMod, 0, 0);
    }

}
