using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = new Vector3(0, 1.4f, 0); 
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed * Time.deltaTime);
	}
}
