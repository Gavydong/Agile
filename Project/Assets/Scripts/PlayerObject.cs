using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerObject : NetworkBehaviour {
	public GameObject PlayerUnitPrefab;
	public float moveSpeed=3;
	GameObject myPlayer;
	// Use this for initialization
	void Start () {
		if (isLocalPlayer == false) 
		{
			//this object belongs to another player.
			return;
		}
		CmdSpawnMyUnit ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isLocalPlayer == false) 
		{
			//this object belongs to another player.
			return;
		}
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		if(h!=0||v!=0)
		//CmdfaceMouse ();
		{Cmdmove(h,v);}

		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

		Vector2 direction = new Vector2 (
			mousePosition.x - transform.position.x, 
			mousePosition.y - transform.position.y
		);
		CmdfaceMouse (direction);
	}
	[Command]
	void CmdSpawnMyUnit()
	{
		GameObject go= Instantiate (PlayerUnitPrefab);
		//Object exsits on the server;
		myPlayer=go;
		NetworkServer.Spawn(go);
	}
	[Command]
	void CmdfaceMouse(Vector2 direction)
	{
//		Vector3 mousePosition = Input.mousePosition;
//		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
//
//		Vector2 direction = new Vector2 (
//			mousePosition.x - transform.position.x, 
//			mousePosition.y - transform.position.y
//		);
		myPlayer.transform.up = direction;

	}
	[Command]

	void Cmdmove(float h,float v)
	{
		//float h = Input.GetAxisRaw ("Horizontal");
		myPlayer.transform.Translate (Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
		//float v = Input.GetAxisRaw ("Vertical");
		myPlayer.transform.Translate (Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

	}
}
