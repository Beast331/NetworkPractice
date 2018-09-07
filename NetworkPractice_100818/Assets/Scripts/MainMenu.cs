using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public InputField matchNameInput;
	public Lobby_Manager lm;

	public void OnClickHost()
	{
		lm.StartMatchMaker ();
		lm.matchMaker.CreateMatch (matchNameInput.text, (uint)lm.maxPlayers, true, "","","",0,0,lm.OnMatchCreate);
	}

}
