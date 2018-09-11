using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Lobby_Manager : NetworkLobbyManager {

	public GameObject lobby;

	void Start()
	{
		lobby.SetActive (false);
	}
	public override void OnStartHost()
	{
		base.OnStartHost();
		Debug.Log ("Game has started lol");
		lobby.SetActive (true);
	}

	public Lobby_Manager()
	{
	}
}
