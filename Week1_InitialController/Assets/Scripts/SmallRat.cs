using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRat : EnemySandbox
{
    
    public override void Move()
    {
        enemySpeed = 10;
        base.MoveLeft();
    }
}
