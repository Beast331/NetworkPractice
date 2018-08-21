using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetworkController : NetworkBehaviour {

	GameController gc;
	// Use this for initialization
	void Start () {
		gc = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ClientRpc]
	public void RpcDisableCanvases()
	{
		Debug.Log ("Disabling...");
		for (int i = 0; i < gc.canvases.Length; i++)
		{
			gc.canvases[i].gameObject.SetActive(false);
		}
	}
}
