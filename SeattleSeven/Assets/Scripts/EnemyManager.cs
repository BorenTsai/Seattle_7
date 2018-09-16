using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject[] Enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("b"))
        {
            //float randomX = Random.Range(-10.0f, 10.0f);
            //float randomZ = Random.Range(-10.0f, 10.0f);
            Attack(0, new Vector3(2.0f, 10.0f, 20.0f), Random.Range(3.0f, 7.0f));
        }
        if (Input.GetKeyDown("g"))
        {
            //float randomX = Random.Range(-10.0f, 10.0f);
            //float randomZ = Random.Range(-10.0f, 10.0f);
            Attack(1, new Vector3(2.0f, 10.0f, 20.0f), Random.Range(3.0f, 7.0f));
        }
        if (Input.GetKeyDown("r"))
        {
            //float randomX = Random.Range(-10.0f, 10.0f);
            //float randomZ = Random.Range(-10.0f, 10.0f);
            Attack(2, new Vector3(2.0f, 10.0f, 20.0f), Random.Range(3.0f, 7.0f));
        }
    }

    void Attack(int enemyNo, Vector3 spawnPosition, float speed)
    {

        PhotonNetwork.Instantiate(Enemy[enemyNo].name, spawnPosition, Quaternion.identity, 0);
/*
        GameObject enemy = Instantiate(Enemy[enemyNo]);
        enemy.transform.position = spawnPosition;
        enemy.GetComponent<Attack>().speed = speed;
  */ 
    }
}
