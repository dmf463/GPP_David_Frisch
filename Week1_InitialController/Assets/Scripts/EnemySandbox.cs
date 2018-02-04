using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySandbox : MonoBehaviour {

    public abstract void Initialize();
    GameObject player;
    public bool isDead;
    public delegate void MyDelegate();
    MyDelegate myDelegate;

    protected virtual void MoveLeft(float enemySpeed)
    {
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
    }

    protected virtual void MoveRight(float enemySpeed)
    {
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }

    protected virtual void MoveUp(float enemySpeed)
    {
        transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
    }

    protected virtual void MoveDown(float enemySpeed)
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
    }

    protected virtual void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void MoveTowardsPlayer(float enemySpeed)
    {
        FindPlayer();
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    protected virtual void SpawnAnotherEnemy(string enemyName)
    {
        GameObject newRat = Instantiate(Resources.Load("Prefabs/" + enemyName)) as GameObject;
        newRat.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-2, 2), transform.position.z);
    }

    protected virtual void OnDeath(MyDelegate onDeath)
    {
        if (isDead)
        {
            onDeath();
        }
    }

	
	// Update is called once per frame
	void Update () {

	}
}
