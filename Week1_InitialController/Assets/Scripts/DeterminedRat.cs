using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminedRat : EnemySandbox {

    public override void Initialize()
    {
        MoveTowardsPlayer(1);
        OnDeath(Repopulate);
    }

    // Update is called once per frame
    void Update () {
        Initialize();
	}

    void Repopulate()
    {
        base.SpawnAnotherEnemy("SmallRat");
        base.SpawnAnotherEnemy("SmallRat");
        base.SpawnAnotherEnemy("SmallRat");
    }
}
