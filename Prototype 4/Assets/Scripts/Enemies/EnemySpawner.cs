using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;

    public float SpawnTime;
    public float SpawnDely;


    public bool stopSpawning = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", SpawnTime, SpawnDely);
	}
	
	// Update is called once per frame
	void SpawnObject () {
        Instantiate(Enemy, transform.position, transform.rotation);

        Enemy.tag = ("Follower");

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
	}
}
