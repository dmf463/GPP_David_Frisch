using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySandbox : MonoBehaviour {

    public abstract void Init();
    public abstract void OnUpdate();
    public float enemySpeed;
    GameObject player;
    public bool isDead;
    public delegate void MyDelegate();
    MyDelegate myDelegate;
    public bool isJumping;
    public float jumpHeight;
    public float jumpTime;

    void Start()
    {
        Init();
    }

    protected virtual void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpTime(jumpTime, jumpHeight));
        }
    }

    protected virtual IEnumerator JumpTime(float time, float jumpHeight)
    {
        yield return new WaitForSeconds(time);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpHeight, 0), ForceMode2D.Impulse);
        isJumping = false;
    }

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
        Services.EnemyManager.enemies.Add(newRat);
        newRat.transform.position = pos;
    }

    protected virtual void OnDeath(MyDelegate onDeath)
    {
        if (isDead)
        {
            onDeath();
            Services.EnemyManager.DestroyEnemy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PizzaShop")
        {
            this.isDead = true;
        }
    }

	
}
