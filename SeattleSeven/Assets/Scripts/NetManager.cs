using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviour {


    public byte Version = 1;

    public GameObject sophiaHead;
    public GameObject sophiaHandL;
    public GameObject sophiaHandR;

    public GameObject[] swordLikeThings; 

    public virtual void Start()
    {
        //connect to the server. 
        //if there is a room on the server, connect to it 
        //if not, create a new room. 
        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
    }

    // below, we implement some callbacks of PUN
    // you can find PUN's callbacks in the class PunBehaviour or in enum PhotonNetworkingMessage


    public virtual void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
        Debug.Log("We are inow nstantiating the VR character onto the network");
        // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
        Vector3 initializationPosition = Vector3.zero;
        Quaternion initializationRotation = Quaternion.identity;
        PhotonNetwork.Instantiate(this.sophiaHead.name, initializationPosition, initializationRotation, 0);
        PhotonNetwork.Instantiate(this.sophiaHandR.name, initializationPosition, initializationRotation, 0);
        PhotonNetwork.Instantiate(this.sophiaHandL.name, initializationPosition, initializationRotation, 0);

        //randomly spawn swords around the player
        int i = 0;
        foreach (GameObject swordLikeThing in this.swordLikeThings)
        {
            //initializationPosition = new Vector3(Random.Range(0, 1), 4, Random.Range(0, 1)); //picks a random spot on the floor near the player.
            initializationPosition = new Vector3(-0.2f + i * 0.47f, 0.96f, 1.28f);
            i++;
            PhotonNetwork.Instantiate(swordLikeThing.name, initializationPosition, initializationRotation   , 0);
        }

    }
}
