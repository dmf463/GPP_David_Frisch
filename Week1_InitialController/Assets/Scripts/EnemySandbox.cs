using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySandbox : MonoBehaviour {

    public abstract void OnUpdate();
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

    protected virtual void SpawnAnotherEnemy(EnemyTypes enemyType, Vector3 pos) //change to spawn enemy at point and pass a vector3
    {
        GameObject newRat = Instantiate(Services.EnemyManager.enemyDict[enemyType]) as GameObject;
        newRat.transform.position = pos;
    }

    protected virtual void OnDeath(MyDelegate onDeath)
    {
        if (isDead)
        {
            onDeath();
            Destroy(gameObject);
        }
    }

	
}
