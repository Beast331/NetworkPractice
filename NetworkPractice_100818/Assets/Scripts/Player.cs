using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
	GameController gc;
	[SyncVar]
	private string username;
	public string userDisplay;
	[SyncVar]
	private Color c;
	void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		if (isLocalPlayer) {
			username = gc.username;
			c = gc.color;
		}
		GetComponent<MeshRenderer> ().material.color = c;
	}
    void Update()
    {
		userDisplay = username;
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}