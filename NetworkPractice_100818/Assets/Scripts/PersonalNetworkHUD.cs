using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class PersonalNetworkHUD : NetworkManager {

	// Use this for initialization
	GameController gc;
	public bool hostCreated;
	private int numberOfSpawns;
	NetworkStartPosition [] startingPositions;

	void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		startingPositions = FindObjectsOfType<NetworkStartPosition>();
	}
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
		if (numberOfSpawns < startingPositions.Length)
			player = (GameObject)Object.Instantiate (playerPrefab, startingPositions [numberOfSpawns].GetComponent<Transform>().position, Quaternion.identity);
		else 
		{
			player = (GameObject)Object.Instantiate (playerPrefab, startingPositions [numberOfSpawns%(startingPositions.Length)].GetComponent<Transform>().position, Quaternion.identity);
		}
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		numberOfSpawns += 1;
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
