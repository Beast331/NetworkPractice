using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class Player : NetworkBehaviour
{
	GameController gc;
	[SyncVar]
	private string username;
	[SyncVar (hook = "changedName")]
	public string userDisplay;
	[SyncVar]
	private Color c;
	private int playerCount;
	void Start()
	{
		DontDestroyOnLoad (this.gameObject);
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		playerCount = gc.players.Count;
		if (isLocalPlayer) {
				PlayerPrefs.SetString ("PlayerName" + playerCount, gc.username);
				username = gc.username;
				c = gc.color;
		}
		GetComponent<MeshRenderer> ().material.color = c;
		userDisplay = username;

	}
    void Update()
    {
		if (isLocalPlayer) {
			Debug.Log ("PlayerName" + playerCount + " " + PlayerPrefs.GetString ("PlayerName" + playerCount));
			userDisplay = PlayerPrefs.GetString ("PlayerName" + playerCount);
		}
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * -3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
		CmdVars (username, c);
    }

	[Command]
	public void CmdVars(string name, Color c)
	{
		userDisplay = name;
		GetComponent<MeshRenderer> ().material.color = c;
	}
	void changedName (string playerName)
	{
		userDisplay = playerName;
	}

		
}