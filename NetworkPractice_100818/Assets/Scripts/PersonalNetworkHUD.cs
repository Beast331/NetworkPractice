using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class PersonalNetworkHUD : NetworkManager {

	// Use this for initialization
	public bool hostCreated;
	public void StartupHost()
	{
		if (hostCreated)
			return;
		SetPort();
		NetworkServer.Reset();
		NetworkManager.singleton.StartHost();
		Debug.Log("StartupHost");
		hostCreated = true;
	}
	
	public void JoinGame(string ip)
	{
		SetIP(ip);
		SetPort();
		NetworkManager.singleton.StartClient();
	}
	
	public override void OnClientConnect(NetworkConnection conn)
    {
		Debug.Log("OnClientConnect");
		ClientScene.Ready(conn);
        ClientScene.AddPlayer(conn, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	
	 public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
    {
		Debug.Log("OnServerAddPlayer");
        GameObject player;
        player = (GameObject)Object.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
 
   /*  public override void OnClientSceneChanged(NetworkConnection conn)
    {
    } */
	
	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}
	
	void SetIP(string ip)
	{
		Debug.Log("Setting IP...");
		NetworkManager.singleton.networkAddress = ip;
	}
}
