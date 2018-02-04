using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRat : EnemySandbox
{
    public override void Initialize()
    {
        MoveLeft(2);
        OnDeath(Death);
    }

    void Update()
    {
        Initialize();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
