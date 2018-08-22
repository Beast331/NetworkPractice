using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public Text userNameField;
	public Text ipField;
	string ipAddress;
	public string username;
	public Canvas [] canvases;
	public Color color;
	PersonalNetworkHUD pnh;
	public Text playerNames;

	// Use this for initialization
	void Start () 
	{
		pnh = GameObject.Find("NetworkManager").GetComponent<PersonalNetworkHUD>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public void userName()
	{
		username = userNameField.text;
		userNameField.text = "";
		canvases[0].enabled = false;
	}
	
	public void colorSelect(string c)
	{
		color = c == "red" ? Color.red : c == "blue" ? Color.blue : Color.green;
		canvases[1].enabled = false;
	}
	
	public void host()
	{
		canvases[2].enabled = false;
		canvases[3].gameObject.SetActive(true);
		foreach (GameObject i in GameObject.FindGameObjectsWithTag("GameController"))
		{
			playerNames.text += i.GetComponent<Player> ().userDisplay + "\n";
		}
		pnh.StartupHost();
	}
	
	public void clientJoin()
	{
		canvases[2].enabled = false;
		canvases[4].gameObject.SetActive(true);
	}
	
	public void enterIP()
	{
		ipAddress = ipField.text;
		ipField.text = "";
		canvases[4].gameObject.SetActive(false);
		canvases[3].gameObject.SetActive(true);
		canvases[3].transform.GetChild(1).gameObject.SetActive(false);
		foreach (GameObject i in GameObject.FindGameObjectsWithTag("Player"))
		{
			playerNames.text += i.GetComponent<Player> ().userDisplay + "\n";
		}
		pnh.JoinGame(ipAddress);
		
	}
		
	public void startGame()
	{
		SceneManager.LoadScene("PlayScene");
		pnh.ServerChangeScene("PlayScene");
	}
}
