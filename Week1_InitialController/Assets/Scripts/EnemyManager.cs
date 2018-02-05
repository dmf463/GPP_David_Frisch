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
    public Dictionary<EnemyTypes, GameObject> enemyDict = new Dictionary<EnemyTypes, GameObject>();
    public void IntitializeEnemies()
    {
        enemyDict.Add(EnemyTypes.SmallRat, Services.PrefabDB.SmallRat as GameObject);
        enemyDict.Add(EnemyTypes.DeterminedRat, Services.PrefabDB.DeterminedRat as GameObject);
        GameObject[] findEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in findEnemies) enemies.Add(enemy);
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
        foreach(GameObject enemy in enemies)
        {
            //need to add a destory list
            enemy.GetComponent<EnemySandbox>().OnUpdate();
        }
    }

    public void SpawnSmallRat()
    {

    }

}
