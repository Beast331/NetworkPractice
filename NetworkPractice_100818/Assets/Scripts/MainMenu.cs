using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public InputField matchNameInput;
	public Lobby_Manager lm;
	public GameObject joinRoomObject;
	JoinRoom jr;

	public void OnClickHost()
	{
		lm.StartMatchMaker ();
		lm.matchMaker.CreateMatch (matchNameInput.text, (uint)lm.maxPlayers, true, "","","",0,0,lm.OnMatchCreate);
	}

	public void OnClickJoin()
	{
		lm.StartMatchMaker ();
		joinRoomObject.SetActive (true);
		jr = joinRoomObject.GetComponent<JoinRoom> ();
		jr.refreshRoom ();
	}

}
