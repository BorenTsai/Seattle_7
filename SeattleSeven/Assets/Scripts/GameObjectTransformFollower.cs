using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTransformFollower : Photon.MonoBehaviour {
    public GameObject objectToTrack; 
    private float speedPosition;
    private float speedRotation;

	// Use this for initialization
	void Start () {

        if (!photonView.isMine)
        {
            return;
        }

        //using StartsWith here is potentially dangerous. 
        if (this.name.StartsWith("Head"))
        {
            objectToTrack = GameObject.Find("CenterEyeAnchor");
        }
        else if (this.name.StartsWith("LeftHand"))
        {
            objectToTrack = GameObject.Find("LeftHandAnchor");
        }
        else if (this.name.StartsWith("RightHand"))
        {
            objectToTrack = GameObject.Find("RightHandAnchor");
        }
        speedPosition = 10.0f;
        speedRotation = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (photonView.isMine || !PhotonNetwork.connected ) { //the second condition is just to make debugging easier
            //smoothly follow target 
            Transform target = objectToTrack.transform;
            transform.position = Vector3.Lerp(transform.position, target.position, speedPosition * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speedRotation * Time.deltaTime);

        }

    }
}
