using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySandbox : MonoBehaviour {

    public abstract void Move();
    protected float enemySpeed; 

    protected virtual void MoveLeft()
    {
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}
}
