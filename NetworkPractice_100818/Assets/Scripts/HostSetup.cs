using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;
using System;
public class HostSetup : MonoBehaviour {

	MatchInfoSnapshot match;
	public Text hostName;
	Lobby_Manager lm;
	GameObject lobbyParent;
	// Use this for initialization
	void Start () {

		lm = GameObject.FindGameObjectWithTag ("NetworkManager").GetComponent<Lobby_Manager> ();
		lobbyParent = GameObject.FindGameObjectWithTag ("LobbyParent");
	}

	public void Setup(MatchInfoSnapshot _match)
	{
		match = _match;
		hostName.text = match.name;
	}

	public void Join()
	{
		if (lm == null) {
			lm = GameObject.FindGameObjectWithTag ("NetworkManager").GetComponent<Lobby_Manager> ();
		}

		var go = lobbyParent.GetComponentsInChildren<Transform> (true);
		foreach (var item in go) 
		{
			item.gameObject.SetActive (true);
		}
		lm.matchMaker.JoinMatch (match.networkId, "", "", "", 0, 0, lm.OnMatchJoined);
	}
}
