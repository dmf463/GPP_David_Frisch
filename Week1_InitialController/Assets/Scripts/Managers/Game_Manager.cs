using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Services.EventManager = new GC.EventManager();
        Services.PrefabDB = Resources.Load<PrefabDB>("Prefabs/PrefabDB");
        Services.EnemyManager = new EnemyManager();
        Services.EnemyManager.IntitializeEnemies();
		
	}
	
	// Update is called once per frame
	void Update () {
        Services.EnemyManager.UpdateEnemy();
	}
}
