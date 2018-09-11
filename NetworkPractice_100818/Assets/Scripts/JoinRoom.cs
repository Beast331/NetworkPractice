using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using System;
using UnityEngine.UI;
public class JoinRoom : MonoBehaviour {

	Lobby_Manager lm;
	public GameObject GamePrefab;
	public GameObject parentForHost;
	// Use this for initialization
	void Start () {
		lm = GameObject.FindGameObjectWithTag ("NetworkManager").GetComponent<Lobby_Manager> ();
	}

	public void refreshRoom()
	{
		if (lm == null) 
		{
			lm = GameObject.FindGameObjectWithTag ("NetworkManager").GetComponent<Lobby_Manager> ();
		}

		if (lm.matchMaker == null) 
		{
			lm.StartMatchMaker ();
		}

		lm.matchMaker.ListMatches (0, 20, "", true, 0, 0, onMatchList);
	}

	private void onMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
	{
		if (!success) 
		{
			Debug.Log ("Refresh");
		}

		foreach(MatchInfoSnapshot match in responseData)
		{
			GameObject ListGameObject = Instantiate (GamePrefab);
			ListGameObject.transform.SetParent (parentForHost.transform);
			HostSetup host = ListGameObject.GetComponent<HostSetup> ();
			host.Setup (match);
		}
			
	}

}
