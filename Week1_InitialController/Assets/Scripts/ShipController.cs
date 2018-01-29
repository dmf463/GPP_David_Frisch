﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move stuff
        Move(Vector3.up, upKey);
        Move(Vector3.down, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);

        //shoot stuff
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<BasicGun>().Fire(Vector3.right, new Vector3(1, 0, 0));
        }

    }

    void Move(Vector3 dir, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}