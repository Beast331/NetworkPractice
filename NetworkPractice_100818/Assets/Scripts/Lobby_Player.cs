using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Lobby_Player : NetworkLobbyPlayer {

	public GameObject ParentPref;

	public override void OnClientEnterLobby()
	{
		base.OnClientEnterLobby ();
		ParentPref = GameObject.FindGameObjectWithTag ("ParentPref");
		gameObject.transform.SetParent (ParentPref.transform);
	}
}
