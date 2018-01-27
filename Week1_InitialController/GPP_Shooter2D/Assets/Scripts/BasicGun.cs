﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{

    //"protected" vars can only be seen by this class and classes that extend this class
    protected string gunName = "BasicGun";
    protected float speed = 20;

    public virtual void Fire(Vector3 dir, Vector3 modPos)
    {
        print("Fired a shot: " + gunName);

        GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
        bullet.transform.position = transform.position + modPos;
        bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
