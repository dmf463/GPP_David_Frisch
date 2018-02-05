using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRat : EnemySandbox
{
    public override void Init()
    {
        enemySpeed = UnityEngine.Random.Range(1, 5);
    }

    public override void OnUpdate()
    {
        MoveLeft(enemySpeed);
        OnDeath(Death);
    }

    private void Death()
    {
        Debug.Log("basic death");
    }
}
