using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject sophiaPrefab;
	// Use this for initialization
	void Start () {

        if (!sophiaPrefab)
        {
            Debug.LogError("Prefab reference not found.Please set it up in GameObject 'GameManager'", this);
        }
        else
        {
            Debug.Log("We are instantiating the VR character onto the network");
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            Vector3 initializationPositon = Vector3.zero;
            Quaternion initializationRotation = Quaternion.identity;
            PhotonNetwork.Instantiate(this.sophiaPrefab.name, initializationPositon, initializationRotation, 0);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
