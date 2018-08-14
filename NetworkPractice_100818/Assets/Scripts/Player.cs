using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
	GameController gc;
	[SyncVar]
	public string username;

	void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		GetComponent<MeshRenderer> ().material.color = gc.color;
		username = gc.username;
	}
    void Update()
    {
		
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