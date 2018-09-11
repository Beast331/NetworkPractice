using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Lobby_Player : NetworkLobbyPlayer {

	public GameObject ParentPref;
	public Button joinButton;
	public Text playerName;
	public Text buttonText;
	public override void OnClientEnterLobby()
	{
		base.OnClientEnterLobby ();
		ParentPref = GameObject.FindGameObjectWithTag ("ParentPref");
		gameObject.transform.SetParent (ParentPref.transform);
		if (isLocalPlayer)
			Setup ();
		else
			SetupOtherPlayers ();
	}

	private void Setup()
	{
			playerName.text = "MyPlayer";
			joinButton.enabled = true;
			buttonText.text = "Join!";
			
	}

	public void onClickJoin()
	{


	}



	public override void OnStartLocalPlayer()
	{
		base.OnStartLocalPlayer();
		if (isLocalPlayer)
			Setup ();
		else
			SetupOtherPlayers ();
	}

	private void SetupOtherPlayers()
	{
		playerName.text = "Not MyPlayer";
		joinButton.enabled = false;
		buttonText.text = "...";
	}
}
