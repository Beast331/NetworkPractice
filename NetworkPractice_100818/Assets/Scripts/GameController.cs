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
	public List<string> players = new List<string>();
	bool nameAdded = false;
	// Use this for initialization
	void Start () 
	{
		pnh = GameObject.Find("NetworkManager").GetComponent<PersonalNetworkHUD>();
	}
	// Update is called once per frame
	void FixedUpdate () 
	{	

		foreach (Player i in Object.FindObjectsOfType(typeof(Player))) {
			if (!players.Contains (i.userDisplay)) {
				players.Add ((i.userDisplay).Trim());
				nameAdded = true;
			}
		}
			if (nameAdded)
			{
				playerNames.text = "Players:";
				foreach (string j in players)
				{
				playerNames.text += "\n" + j;
				}
			}
			nameAdded = false;

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
		canvases[3].transform.GetChild(3).gameObject.SetActive(false);
		pnh.JoinGame(ipAddress);
		
	}
		
	public void startGame()
	{
		foreach (Player i in Object.FindObjectsOfType(typeof(Player)))
		{
			DontDestroyOnLoad (i.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
		DontDestroyOnLoad (pnh.gameObject);
		SceneManager.LoadScene("PlayScene");
		pnh.ServerChangeScene("PlayScene");
	}
		
}
