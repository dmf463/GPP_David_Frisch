using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRat : EnemySandbox
{
    public override void OnUpdate()
    {
        MoveLeft(2);
        OnDeath(Death);
    }

    private void Death()
    {
        Debug.Log("basic death");
    }
}
