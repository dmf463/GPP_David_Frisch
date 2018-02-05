using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminedRat : EnemySandbox {

    public override void Init()
    {
        enemySpeed = UnityEngine.Random.Range(1, 5);
    }
    public override void OnUpdate()
    {
        MoveTowardsPlayer(enemySpeed);
        OnDeath(Repopulate);
    }

    void Repopulate()
    {
        Vector3 spawnPos1 = new Vector3(transform.position.x + UnityEngine.Random.Range(- 2, 2), transform.position.y, transform.position.z);
        Vector3 spawnPos2 = new Vector3(transform.position.x + UnityEngine.Random.Range(-2, 2), transform.position.y, transform.position.z);
        Vector3 spawnPos3 = new Vector3(transform.position.x + UnityEngine.Random.Range(-2, 2), transform.position.y, transform.position.z);
        base.SpawnAnotherEnemy(EnemyTypes.SmallRat, spawnPos1);
        base.SpawnAnotherEnemy(EnemyTypes.SmallRat, spawnPos2);
        base.SpawnAnotherEnemy(EnemyTypes.SmallRat, spawnPos3);
    }
}
