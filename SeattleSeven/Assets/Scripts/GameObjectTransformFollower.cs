using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTransformFollower : MonoBehaviour {
    public GameObject objectToTrack; 
    private float speedPosition;
    private float speedRotation;
    public bool isMine = true; //only the owner of the avatar can make it move, not the networked users. 

	// Use this for initialization
	void Start () {
        if (!isMine)
        {
            return;
        }

        if (this.name == "Head")
        {
            objectToTrack = GameObject.Find("CenterEyeAnchor");
        }
        else if (this.name == "LeftHand")
        {
            objectToTrack = GameObject.Find("LeftHandAnchor");
        }
        else if (this.name == "RightHand")
        {
            objectToTrack = GameObject.Find("RightHandAnchor");
        }
        speedPosition = 10.0f;
        speedRotation = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (isMine || !PhotonNetwork.connected ) { //the second condition is just to make debugging easier
            //smoothly follow target 
            Transform target = objectToTrack.transform;
            transform.position = Vector3.Lerp(transform.position, target.position, speedPosition * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speedRotation * Time.deltaTime);

        }

    }
}
